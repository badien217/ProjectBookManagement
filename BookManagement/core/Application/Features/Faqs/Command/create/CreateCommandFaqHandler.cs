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

namespace Application.Features.Faqs.Command.create
{
    public class CreateCommandFaqHandler : BaseHandler, IRequestHandler<CreateCommandFaqRequest, Unit>
    {
        public CreateCommandFaqHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateCommandFaqRequest request, CancellationToken cancellationToken)
        {
            Faq faq = new(request.question, request.answer);
            await unitOfWork.GetWriteReponsitory<Faq>().AddAsync(faq);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
