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

namespace Application.Features.Faqs.Queries.GetOne
{
    public class GetOneQueriesFaqHandler : BaseHandler, IRequestHandler<GetOneQueriesFaqRequest, GetOneQueriesFaqReponse>
    {
        public GetOneQueriesFaqHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<GetOneQueriesFaqReponse> Handle(GetOneQueriesFaqRequest request, CancellationToken cancellationToken)
        {
            var faq = await unitOfWork.GetReadReponsitory<Faq>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            var map = mapper.Map<GetOneQueriesFaqReponse, Faq>(faq);
            return map;
        }
    }
}
