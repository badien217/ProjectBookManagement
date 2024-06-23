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

namespace Application.Features.Books.Command.Delete
{
    public class DeleteBookCommandHandler : BaseHandler, IRequestHandler<DeleteBookCommandRequest, Unit>
    {
        public DeleteBookCommandHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }
        public async Task<Unit> Handle(DeleteBookCommandRequest request, CancellationToken cancellationToken)
        {
            var book = await unitOfWork.GetReadReponsitory<Book>().GetAsync(x => x.Id == request.id && !x.IsDeleted);
            book.IsDeleted = true;
            await unitOfWork.GetWriteReponsitory<Book>().UpdateAsync(book);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
