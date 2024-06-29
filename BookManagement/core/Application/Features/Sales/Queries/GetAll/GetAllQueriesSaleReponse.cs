using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sales.Queries.GetAll
{
    public class GetAllQueriesSaleReponse
    {
        public string name { get; set; }
        public string description { get; set; }
        public long percentageSale { get; set; }
        public DateTime endDate { get; set; }
    }
}
