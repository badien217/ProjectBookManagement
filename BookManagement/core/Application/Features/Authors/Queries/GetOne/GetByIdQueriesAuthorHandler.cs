using Application.Base;
using Application.Interfaces.AutoMapping;
using Application.Interfaces.UnitOfWork;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authors.Queries.GetOne
{
    public class GetByIdQueriesAuthorHandler : BaseHandler, IRequestHandler<GetByIdQueriesAuthorRequest, GetByIdQueriesAuthorReponse>
    {
        public GetByIdQueriesAuthorHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<GetByIdQueriesAuthorReponse> Handle(GetByIdQueriesAuthorRequest request, CancellationToken cancellationToken)
        {
            var author = await unitOfWork.GetReadReponsitory<Author>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            var map = mapper.Map< GetByIdQueriesAuthorReponse,Author >(author);
           
            return map;

        }
    }
}
