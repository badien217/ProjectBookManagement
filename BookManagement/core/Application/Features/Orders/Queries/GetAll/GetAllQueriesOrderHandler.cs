using Application.Base;
using Application.Dtos;
using Application.Interfaces.AutoMapping;
using Application.Interfaces.UnitOfWork;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetAll
{
    public class GetAllQueriesOrderHandler : BaseHandler, IRequestHandler<GetAllQueriesOrderRequest, IList<GetAllQueriesOrderReponse>>
    {
        public GetAllQueriesOrderHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllQueriesOrderReponse>> Handle(GetAllQueriesOrderRequest request, CancellationToken cancellationToken)
        {
            var orderDetails = await unitOfWork.GetReadReponsitory<OrderDetail>()
    .       GetAllAsync(include: x => x
            .Include(b => b.Books).ThenInclude(c => c.Select(y => y.author)) 
            );
            var map = mapper.Map<AuthorDtos, Author>(new Author());
            var map1 = mapper.Map<BookDtos,Book>(new Book());

        }
    }
}
