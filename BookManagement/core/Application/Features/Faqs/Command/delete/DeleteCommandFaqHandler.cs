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

namespace Application.Features.Faqs.Command.delete
{
    public class DeleteCommandFaqHandler : BaseHandler, IRequestHandler<DeleteCommandFaqRequest, Unit>
    {
        public DeleteCommandFaqHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(DeleteCommandFaqRequest request, CancellationToken cancellationToken)
        {
            var faq = await unitOfWork.GetReadReponsitory<Faq>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            faq.IsDeleted = true;
            await unitOfWork.GetWriteReponsitory<Faq>().UpdateAsync(faq);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
