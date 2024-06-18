using Application.Interfaces.Token;
using Domain.Entity;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Token
{
    public class TokenSevices : ITokenServices
    {
        private readonly UserManager<User> userManager;// Việc tạo userManager sử dụng để quản lý các thao tác liên quan đến người dùng như tạo, cập nhật, xóa và tìm kiếm người dùng
        private readonly TokenSetting tokenSettings;//chứa các thiết lập cấu hình liên quan đến mã thông báo (tokens)
        public TokenSevices(IOptions<TokenSetting> options, UserManager<User> userManager)
        {
            tokenSettings = options.Value;// option.value chứa các thiết lập thực tế của TokenSetting
            this.userManager = userManager;
        }
        public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };// tạo 1 claim để chứa thông tin người dùng ,đảm bảo an toàn trong quá trình truyền tải
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }// duyệt mảng role sau đó add vào claims
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret));// Đây là khóa bí mật dùng để ký và giải mã mã thông báo JWT
            var token = new JwtSecurityToken(// khởi tạo đối tượng JwtSecurity Token với các thông số sau
                issuer: tokenSettings.Issuer,//nhà phát hành sẽ được cấu hình bên TokenSetting.Issuser
                audience: tokenSettings.Audience,// người được ủy quyền cx được cấu hình như vậy
                expires: DateTime.Now.AddMinutes(tokenSettings.TokenValidityInMunitues),//thời hoạn được cấu hình 
                claims: claims,// claim sẽ được cấu hình ở phía trên
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)// chữ ký sẽ theo chuẩn HmacSha256
                );
            await userManager.AddClaimsAsync(user, claims);// add thông tin đó userManager,Điều này có thể cần thiết để lưu trữ các claims trong cơ sở dữ liệu hoặc sử dụng cho mục đích khác

            return token;

        }

        public string GenerateRefreshToken()// Phương thức này được sinh ra để tạo một mã thông báo làm mới refreshToken 
        {
            var randomNumber = new byte[64];// tạo 1 mảng byte ngẫu nhiêu
            using var rng = RandomNumberGenerator.Create();//tạo ra các byte ngẫu nhiên
            rng.GetBytes(randomNumber);//điền các byte ngẫu nhiên vào mảng 
            return Convert.ToBase64String(randomNumber);// chuyển đổi và trả về dưới dạng json
        }
        //Phương thức GetPrincipalFromExpiredToken này được sử dụng để lấy thông tin xác thực (principal) từ một mã thông báo JWT đã hết hạn
        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters()//cấu hình các tham số xác thực mã thông báo
            {
                ValidateIssuer = false,// không xác thực nhà phát hành của mã thông báo
                ValidateAudience = false,//không xác thực đối tượng nhận của mã thông báo
                ValidateIssuerSigningKey = true,// xác thực khóa ký của mã thông báo
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Issuer)),// dùng tokenSettings.Issuer để xác thực mã thông báo
                ValidateLifetime = false,//Không xác thực thời hạn sống của mã thông báo
            };
            JwtSecurityTokenHandler tokenHandler = new();// tạo 1 đối tượng JwtSecurityTokenHandler để xử lý mã thông báo
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);//xác thực mã thông báo dựa trên các tham số cấu hình có sẵn
            // ngoài ra sẽ trả về ClaimPrincial và cung cấp securityToken đã xác thực
            if (securityToken is not JwtSecurityToken jwtSecurityToken//nếu securityToken không phải là JwtSecurityToken 
                || !jwtSecurityToken.Header.Alg 
                .Equals(SecurityAlgorithms.HmacSha256,//Kiểm tra xem thuật toán ký (algorithm) của mã thông báo có phải là HmacSha256 hay không
                StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("token not found.");// nếu không sẽ bắn ra Exception

            return principal;

        }
    }
    
}
