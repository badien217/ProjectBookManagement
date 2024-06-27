using Application.Interfaces.Token;
using infrastructure.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace infrastructure
{
    public static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            services.Configure<TokenSetting>(configuration.GetSection("JWT"));//sử dụng để cấu hình và đăng ký một lớp cấu hình (TokenSetting) trong dịch vụ .NET
            services.AddTransient<ITokenServices, TokenSevices>();//đăng ký sử dụng trên .net
            //cấu hình xác thực JWT (JSON Web Token) bằng cách sử dụng middleware Authentication và JWT Bearer Authentication
            //cho phép ứng dụng xác thực và ủy quyền người dùng dựa trên các token JWT
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;// Đặt scheme mặc định để xác thực
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;// Đặt scheme mặc định để thách thức
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>// thêm cấu hình Jwt 
            {
                opt.SaveToken = true;// cho phép lưu trữ cấu hình 
                opt.TokenValidationParameters = new TokenValidationParameters()// cấu hình các tham số thực token
                {
                    ValidateIssuer = false,// không xác nhận nhà phát hành
                    ValidateAudience = false,// không xác nhận người được ủy quyền
                    ValidateIssuerSigningKey = true,//yêu cầu khóa của nhà phát hành
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),// Đặt khóa bí mật để xác thực chữ ký của token, được lấy từ cấu hình (configuration["JWT:Secret"]).
                    ValidateLifetime = false,//không xác nhận chữ ký của token 
                    ValidIssuer = configuration["JWT:Issuer"],//Xác nhận rằng Issuer của token phải trùng với giá trị cấu hình (JWT:Issuer)
                    ValidAudience = configuration["JWT:Audience"],//như issuer
                    ClockSkew = TimeSpan.Zero//Đặt khoảng thời gian cho phép sai số giữa thời gian máy chủ và thời gian của token là 0
                };
            });
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = configuration["RedisCacheSettings:ConnectionString"];
                opt.InstanceName = configuration["RedisCacheSettings:InstanceName"];
            });
        }
    }
}
