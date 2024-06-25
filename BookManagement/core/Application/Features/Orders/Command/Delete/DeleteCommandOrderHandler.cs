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

namespace Application.Features.Orders.Command.Delete
{
    public class DeleteCommandOrderHandler : BaseHandler, IRequestHandler<DeleteCommandOrderRequest, Unit>
    {
        public DeleteCommandOrderHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(DeleteCommandOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await unitOfWork.GetReadReponsitory<Order>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            order.IsDeleted = true;
            await unitOfWork.GetWriteReponsitory<Order>().UpdateAsync(order);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
