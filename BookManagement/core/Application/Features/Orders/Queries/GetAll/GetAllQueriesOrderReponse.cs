using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetAll
{
    public class GetAllQueriesOrderReponse
    {
        public OrderDto Order { get; set; }
        public BookDtos Book { get; set; }  
       
    }
}
