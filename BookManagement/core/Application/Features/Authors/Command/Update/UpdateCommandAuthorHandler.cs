using Application.Base;
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

namespace Application.Features.Authors.Command.Update
{
    public class UpdateCommandAuthorHandler : BaseHandler, IRequestHandler<UpdateCommandAuthorRequest, Unit>
    {
        public UpdateCommandAuthorHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(UpdateCommandAuthorRequest request, CancellationToken cancellationToken)
        {
            var author = await unitOfWork.GetReadReponsitory<Author>().GetAsync(x => x.Id == request.id && !x.IsDeleted);
            var map = mapper.Map<Author, UpdateCommandAuthorRequest>(request);
            await unitOfWork.GetWriteReponsitory<Author>().UpdateAsync(map);
            return Unit.Value;
        }
    }
}
