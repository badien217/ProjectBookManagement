using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sales.Queries.GetOne
{
    public class GetByIdQueriesSaleRequest : IRequest<GetByIdQueriesSaleReponse>
    {
        public int Id { get; set; }
    }
}
