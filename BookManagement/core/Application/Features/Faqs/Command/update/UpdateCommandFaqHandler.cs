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

namespace Application.Features.Faqs.Command.update
{
    public class UpdateCommandFaqHandler : BaseHandler, IRequestHandler<UpdateCommandFaqRequest, Unit>
    {
        public UpdateCommandFaqHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(UpdateCommandFaqRequest request, CancellationToken cancellationToken)
        {
            var faq = await unitOfWork.GetReadReponsitory<Faq>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            var map = mapper.Map< Faq,UpdateCommandFaqRequest>(request);
            await unitOfWork.GetWriteReponsitory<Faq>().UpdateAsync(map);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
