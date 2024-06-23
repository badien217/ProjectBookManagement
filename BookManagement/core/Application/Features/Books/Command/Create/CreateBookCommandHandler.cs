using Application.Base;
using Application.Interfaces.AutoMapping;
using Application.Interfaces.UnitOfWork;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Application.Features.Books.Command.Create
{
    public class CreateBookCommandHandler :  IRequestHandler<CreateBookCommandRequest, Unit>
    {
        public IUnitOfWork _unitOfWork;
        public IAutoMapper _mapper;
        public CreateBookCommandHandler() { }
        public CreateBookCommandHandler(IUnitOfWork unitOfWork, IAutoMapper autoMapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = autoMapper;
           
        }
        public async Task<Unit> Handle(CreateBookCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Book> books = await _unitOfWork.GetReadReponsitory<Book>().GetAllAsync();
            //await BookRules.BookTitleMostNotBeSame(books, request.Title);
            var bookNew = new Book { Title = request.Title, ImageUrl = request.ImageUrl,Price = request.Price,AuthorId = request.AuthorId,filePDF = request.filePDF,Quantity = request.Quantity }
            await _unitOfWork.GetWriteReponsitory<Book>().AddAsync(bookNew);
            if(await _unitOfWork.SaveAsync() > 0)
            {
                foreach(var collectionid in request.CollectionId)
                {
                    await _unitOfWork.GetWriteReponsitory<CollectionDetail>().AddAsync(
                        new()
                        {
                            collectionId = collectionid,
                            bookId = bookNew.Id,
                        }
                        );
                        
                }
                await _unitOfWork.SaveAsync();

            }
            return Unit.Value;
            
        }
    }
}
