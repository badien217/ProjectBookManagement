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

namespace Application.Features.Sales.Queries.GetOne
{
    public class GetByIdQueriesSaleHandler : BaseHandler, IRequestHandler<GetByIdQueriesSaleRequest, GetByIdQueriesSaleReponse>
    {
        public GetByIdQueriesSaleHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<GetByIdQueriesSaleReponse> Handle(GetByIdQueriesSaleRequest request, CancellationToken cancellationToken)
        {
            var sale = await unitOfWork.GetReadReponsitory<Sale>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            var map = mapper.Map<GetByIdQueriesSaleReponse, Sale>(sale);
            return map;
        }
    }
}
