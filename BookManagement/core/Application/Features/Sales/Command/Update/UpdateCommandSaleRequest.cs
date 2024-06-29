using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sales.Command.Update
{
    public class UpdateCommandSaleRequest: IRequest<Unit>
    {
        public int Id { get; set; } 
        public string name { get; set; }
        public string description { get; set; }
        public long percentageSale { get; set; }
        public DateTime endDate { get; set; }
    }
}
 