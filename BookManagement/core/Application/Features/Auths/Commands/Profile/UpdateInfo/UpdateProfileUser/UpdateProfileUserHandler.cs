using Application.Base;
using Application.Features.Auths.Rules;
using Application.Interfaces.AutoMapping;
using Application.Interfaces.UnitOfWork;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Profile.UpdateInfo.UpdateProfileUser
{
    public class UpdateProfileUserHandler : BaseHandler, IRequestHandler<UpdateProfileUserRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAutoMapper _autoMapper;
        private readonly AuthRule Rule;
        public UpdateProfileUserHandler(AuthRule Rule, IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this._unitOfWork = unitOfWork;
            this._autoMapper = mapper;
            this.Rule = Rule;
        }

        public async Task<Unit> Handle(UpdateProfileUserRequest request, CancellationToken cancellationToken)
        {
            UserProfile profile = await unitOfWork.GetReadReponsitory<UserProfile>().GetAsync(x => x.UserId == request.UserId && !x.IsDeleted);
            var map = _autoMapper.Map<UserProfile, UpdateProfileUserRequest>(request);
            if (request.avatar.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", request.avatar.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await request.avatar.CopyToAsync(stream);


                }
                map.avatar = "/image/" + request.avatar.FileName;
            }
            await _unitOfWork.GetWriteReponsitory<UserProfile>().UpdateAsync(map);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
