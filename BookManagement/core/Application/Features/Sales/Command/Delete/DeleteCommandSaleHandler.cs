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

namespace Application.Features.Sales.Command.Delete
{
    public class DeleteCommandSaleHandler : BaseHandler, IRequestHandler<DeleteCommandSaleRequest, Unit>
    {
        public DeleteCommandSaleHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(DeleteCommandSaleRequest request, CancellationToken cancellationToken)
        {
            var sale = await unitOfWork.GetReadReponsitory<Sale>().GetAsync(x => x.Id == request.Id);
            sale.IsDeleted = true;
            await unitOfWork.GetWriteReponsitory<Sale>().UpdateAsync(sale);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
