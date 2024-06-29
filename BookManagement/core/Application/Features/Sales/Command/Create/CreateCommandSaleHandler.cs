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

namespace Application.Features.Sales.Command.Create
{
    public class CreateCommandSaleHandler : BaseHandler, IRequestHandler<CreateCommandSaleRequest, Unit>
    {
        public CreateCommandSaleHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateCommandSaleRequest request, CancellationToken cancellationToken)
        {
            Sale sale = new Sale(request.name,request.description,request.percentageSale,request.endDate);
            await unitOfWork.GetWriteReponsitory<Sale>().AddAsync(sale);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
