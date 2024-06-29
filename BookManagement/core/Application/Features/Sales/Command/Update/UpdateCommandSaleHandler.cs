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

namespace Application.Features.Sales.Command.Update
{
    public class UpdateCommandSaleHandler : BaseHandler, IRequestHandler<UpdateCommandSaleRequest, Unit>
    {
        public UpdateCommandSaleHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(UpdateCommandSaleRequest request, CancellationToken cancellationToken)
        {
            var sale = await unitOfWork.GetReadReponsitory<Sale>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            var map = mapper.Map< Sale,UpdateCommandSaleRequest>(request);
            await unitOfWork.GetWriteReponsitory<Sale>().UpdateAsync(map);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
