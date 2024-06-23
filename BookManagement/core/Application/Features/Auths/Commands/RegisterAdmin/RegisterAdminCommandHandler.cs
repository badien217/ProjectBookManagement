using Application.Base;
using Application.Features.Auths.Rules;
using Application.Interfaces.AutoMapping;
using Application.Interfaces.UnitOfWork;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.RegisterAdmin
{
    public class RegisterAdminCommandHandler : BaseHandler, IRequestHandler<RegisterAdminCommandRequest, Unit>
    {
        private readonly AuthRule authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        public RegisterAdminCommandHandler(AuthRule authRules, UserManager<User> userManager, RoleManager<Role> roleManager, IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;

        }
        public async Task<Unit> Handle(RegisterAdminCommandRequest request, CancellationToken cancellationToken)
        {
            await authRules.UserShouldNotExist(await userManager.FindByEmailAsync(request.email));

            User user = mapper.Map<User, RegisterAdminCommandRequest>(request);
            user.UserName = request.email;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = await userManager.CreateAsync(user, request.password);
            if (result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync("admin"))
                    await roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = "admin",
                        NormalizedName = "ADMIN",
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                    });

                await userManager.AddToRoleAsync(user, "admin");
            }

            return Unit.Value;
        }
    }
}
