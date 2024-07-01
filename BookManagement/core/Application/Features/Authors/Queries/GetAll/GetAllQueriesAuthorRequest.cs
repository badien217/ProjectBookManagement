using Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authors.Queries.GetAll
{
    public class GetAllQueriesAuthorRequest : IRequest<IList<GetAllQueriesAuthorReponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllAuthor";

        public double CacheTime => 60;
    }
}
