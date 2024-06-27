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

namespace Application.Features.Collections.Command.Update
{
    public class UpdateCommandCollectionHandler : BaseHandler, IRequestHandler<UpdateCommandCollectionRequest, Unit>
    {
        public UpdateCommandCollectionHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(UpdateCommandCollectionRequest request, CancellationToken cancellationToken)
        {
            var collection = await unitOfWork.GetReadReponsitory<Collection>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            var map = mapper.Map<Collection, UpdateCommandCollectionRequest >(request);
            await unitOfWork.GetWriteReponsitory<Collection>().UpdateAsync(collection);
            await unitOfWork.SaveAsync();
            return Unit.Value;

        }
    }
}
