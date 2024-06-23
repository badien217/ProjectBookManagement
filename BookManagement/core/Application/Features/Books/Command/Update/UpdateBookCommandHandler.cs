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

namespace Application.Features.Books.Command.Update
{
    public class UpdateBookCommandHandler : BaseHandler, IRequestHandler<UpdateBookCommandRequest, Unit>
    {
        public UpdateBookCommandHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }
        public async Task<Unit> Handle(UpdateBookCommandRequest request, CancellationToken cancellationToken)
        {
            var books = await unitOfWork.GetReadReponsitory<Book>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            var map = mapper.Map<Book, UpdateBookCommandRequest>(request);
            var collectionDetail = await unitOfWork.GetReadReponsitory<CollectionDetail>().GetAllAsync(x => x.bookId == request.Id && !x.IsDeleted);
            await unitOfWork.GetWriteReponsitory<CollectionDetail>().HardDeleteRangerAsync(collectionDetail);
            foreach( var collectionID in request.CollectionId)
            {
                await unitOfWork.GetWriteReponsitory<CollectionDetail>().AddAsync(new()
                {
                    collectionId = collectionID,
                    bookId = books.Id

                }) ;
            }
            await unitOfWork.GetWriteReponsitory<Book>().UpdateAsync(map);
            await unitOfWork.SaveAsync();
            return Unit.Value;


        }
    }
}
