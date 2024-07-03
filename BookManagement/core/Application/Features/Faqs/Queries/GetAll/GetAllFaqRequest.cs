using Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Faqs.Queries.GetAll
{
    public class GetAllFaqRequest : IRequest<IList<GetAllFaqReponse>>, ICacheableQuery

    {
        public string CacheKey => "GetAllFaq";

        public double CacheTime => 60;
    }
}
