using Application.Base;
using Application.Interfaces.AutoMapping;
using Application.Interfaces.RedisCache;
using Application.Interfaces.UnitOfWork;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authors.Queries.GetOne
{
    public class GetByIdQueriesAuthorHandler : BaseHandler, IRequestHandler<GetByIdQueriesAuthorRequest, GetByIdQueriesAuthorReponse>
    {
        private readonly IRedisCache _cache;
        private readonly IDistributedCache _client;
        public GetByIdQueriesAuthorHandler(IRedisCache cache, IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IDistributedCache _client) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this._cache = cache;
            this._client = _client;
        }

        public async Task<GetByIdQueriesAuthorReponse> Handle(GetByIdQueriesAuthorRequest request, CancellationToken cancellationToken)
        {
            var author = await _cache.GetAsync<GetByIdQueriesAuthorReponse>(request.id);
            string key = "GetAllAuthor";
            var map = mapper.Map<GetByIdQueriesAuthorReponse>(this._cache.SetAsync(key, author));
            
            return map;
                
        }
    }
}
