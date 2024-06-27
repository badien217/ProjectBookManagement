using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetOne
{
    public class GetOrderByIdReponse
    {
        public OrderDto Order { get; set; }
        public BookDtos Book { get; set; }
    }
}
