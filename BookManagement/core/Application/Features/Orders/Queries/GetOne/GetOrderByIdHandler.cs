using Application.Base;
using Application.Dtos;
using Application.Features.Orders.Queries.GetAll;
using Application.Interfaces.AutoMapping;
using Application.Interfaces.UnitOfWork;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetOne
{
    public class GetOrderByIdHandler : BaseHandler, IRequestHandler<GetOrderByIdRequest, GetOrderByIdReponse>
    {
        public GetOrderByIdHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<GetOrderByIdReponse> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
        {
            var orderDetails = await unitOfWork.GetReadReponsitory<OrderDetail>()
    .GetAsync(include: x => x
            .Include(b => b.Books )
            ); ;

            var map1 = mapper.Map<BookDtos, Book>(new Book());
            //var map = mapper.Map<AuthorDtos, Author>(new Author());
            var map2 = mapper.Map<OrderDto, Order>(new Order());
            var order = mapper.Map<GetOrderByIdReponse, OrderDetail>(orderDetails);
            return order;
        }
    }
}
