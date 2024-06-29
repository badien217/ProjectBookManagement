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

namespace Application.Features.Sales.Queries.GetAll
{
    public class GetAllQueriesSaleHandler : BaseHandler, IRequestHandler<GetAllQueriesSaleRequest, IList<GetAllQueriesSaleReponse>>
    {
        public GetAllQueriesSaleHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllQueriesSaleReponse>> Handle(GetAllQueriesSaleRequest request, CancellationToken cancellationToken)
        {
            var sale = await unitOfWork.GetReadReponsitory<Sale>().GetAllAsync( X => !X.IsDeleted);
            var map = mapper.Map< GetAllQueriesSaleReponse ,Sale>(sale);
            return map;
        }
    }
}
