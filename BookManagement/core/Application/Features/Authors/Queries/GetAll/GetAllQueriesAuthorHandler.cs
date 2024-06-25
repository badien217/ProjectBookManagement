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

namespace Application.Features.Authors.Queries.GetAll
{
    public class GetAllQueriesAuthorHandler : BaseHandler, IRequestHandler<GetAllQueriesAuthorRequest, IList<GetAllQueriesAuthorReponse>>
    {
        public GetAllQueriesAuthorHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllQueriesAuthorReponse>> Handle(GetAllQueriesAuthorRequest request, CancellationToken cancellationToken)
        {
            IList<Author> author = await unitOfWork.GetReadReponsitory<Author>().GetAllAsync();
            var map = mapper.Map<GetAllQueriesAuthorReponse, Author>(author);
            return map;
        }
    }
}
