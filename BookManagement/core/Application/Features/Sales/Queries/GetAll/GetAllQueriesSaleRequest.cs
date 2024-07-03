using Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sales.Queries.GetAll
{
    public class GetAllQueriesSaleRequest : IRequest<IList<GetAllQueriesSaleReponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllSale";

        public double CacheTime => 60;
    }
}
