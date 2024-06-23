using Application.Base;
using Application.Features.Auths.Rules;
using Application.Interfaces.AutoMapping;
using Application.Interfaces.Token;
using Application.Interfaces.UnitOfWork;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandReponse>
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;
        private readonly ITokenServices tokenService;
        private readonly AuthRule authRules;
        private readonly IUnitOfWork unitOfWork;

        public LoginCommandHandler(UserManager<User> userManager, IConfiguration configuration,
            ITokenServices tokenService, AuthRule authRules, IAutoMapper mapper, IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.tokenService = tokenService;
            this.authRules = authRules;
            this.unitOfWork = unitOfWork;

        }
        public async Task<LoginCommandReponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await userManager.FindByEmailAsync(request.Email);//khai báo đối tượng user và gán nó từ giá trị là findByEmail
            bool checkPassword = await userManager.CheckPasswordAsync(user, request.Password);// check pass đúng không
            await authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);// nếu có trả về exception 
            IList<string> roles = await userManager.GetRolesAsync(user);// lấy ra role người dùng
            string id = await userManager.GetUserIdAsync(user);// lấy ra id người dùng
            var userProfile = await unitOfWork.GetReadReponsitory<UserProfile>().GetAsync(x => x.UserId == new Guid(id));// lấy ra userProfile
            await authRules.checkAccount(userProfile.IsDeleted);// check account đã bị xóa ch
            JwtSecurityToken token = await tokenService.CreateToken(user, roles);// tạo 1 token với user và roles chuyền vào
            string refreshToken = tokenService.GenerateRefreshToken();
            _ = int.TryParse(configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);
            string _token = new JwtSecurityTokenHandler().WriteToken(token);

            await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

            return new()
            {
                Token = _token,
                RefreshToken = refreshToken,
                Expiration = token.ValidTo,
                Role = roles,
                IdClient = id,


            };

        }
    }
}
