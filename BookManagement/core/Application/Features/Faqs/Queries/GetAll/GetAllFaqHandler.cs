using Application.Base;
using Application.Interfaces.AutoMapping;
using Application.Interfaces.UnitOfWork;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Faqs.Queries.GetAll
{
    public class GetAllFaqHandler : BaseHandler, IRequestHandler<GetAllFaqRequest, IList<GetAllFaqReponse>>
    {
        public GetAllFaqHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllFaqReponse>> Handle(GetAllFaqRequest request, CancellationToken cancellationToken)
        {
            var faq = await unitOfWork.GetReadReponsitory<Faq>().GetAllAsyncPacing(x => !x.IsDeleted);
            var map = mapper.Map<GetAllFaqReponse, Faq>(faq);
            return map;
        }
    }
}
