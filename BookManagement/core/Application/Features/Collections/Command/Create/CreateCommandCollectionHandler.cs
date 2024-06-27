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

namespace Application.Features.Collections.Command.Create
{
    public class CreateCommandCollectionHandler : BaseHandler, IRequestHandler<CreateCommandCollectionRequest, Unit>
    {
        public CreateCommandCollectionHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateCommandCollectionRequest request, CancellationToken cancellationToken)
        {
            var Collection = new Collection {name = request.name,content = request.content,saleId = request.saleId };
            await unitOfWork.GetWriteReponsitory<Collection>().AddAsync(Collection);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
