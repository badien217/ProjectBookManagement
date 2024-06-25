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

namespace Application.Features.Orders.Command.Create
{
    public class CreateCommadOrderHandler : BaseHandler, IRequestHandler<CreateCommadOrderRequest, Unit>
    {
        public CreateCommadOrderHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateCommadOrderRequest request, CancellationToken cancellationToken)
        {
            Order order = new(request.Name, request.Email, request.Phone, request.Address, request.Amount,
                request.PaymentOption, request.TransactionStatus,request.checkStatus);
           
            await unitOfWork.GetWriteReponsitory<Order>().AddAsync(order);

            if (await unitOfWork.SaveAsync() > 0)
            {
                foreach (var bookId in request.BookId)
                {
                    await unitOfWork.GetWriteReponsitory<OrderDetail>().AddAsync(new()
                    {
                        OrderId = order.Id,
                        BookId = bookId,
                    });

                }

                await unitOfWork.SaveAsync();
            }
            return Unit.Value;
        }
    }
}
