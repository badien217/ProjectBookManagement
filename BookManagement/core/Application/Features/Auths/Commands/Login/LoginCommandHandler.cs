using Application.Base;
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
        //private readonly AuthRule authRules;
        private readonly IUnitOfWork unitOfWork;

        public LoginCommandHandler(UserManager<User> userManager, IConfiguration configuration,
            ITokenServices tokenService, IAutoMapper mapper, IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.tokenService = tokenService;
            this.unitOfWork = unitOfWork;

        }
        public Task<LoginCommandReponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
