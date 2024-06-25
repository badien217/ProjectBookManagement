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

namespace Application.Features.Authors.Command.Delete
{
    public class DeleteCommandAuthorHandler : BaseHandler, IRequestHandler<DeleteCommandAuthorRequest, Unit>
    {
        public DeleteCommandAuthorHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }
        public async Task<Unit> Handle(DeleteCommandAuthorRequest request, CancellationToken cancellationToken)
        {
            var author = await unitOfWork.GetReadReponsitory<Author>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            author.IsDeleted = true;
            await unitOfWork.GetWriteReponsitory<Author>().UpdateAsync(author);
            return Unit.Value;
        }
    }
}
