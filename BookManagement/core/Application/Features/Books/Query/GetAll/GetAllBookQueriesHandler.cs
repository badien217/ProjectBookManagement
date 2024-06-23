using Application.Base;
using Application.Dtos;
using Application.Interfaces.AutoMapping;
using Application.Interfaces.UnitOfWork;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Query.GetAll
{
    public class GetAllBookQueriesHandler : BaseHandler, IRequestHandler<GetAllBookQueriesRequest, IList<GetAllBookQueriesReponse>>
    {
        public GetAllBookQueriesHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }
        public async Task<IList<GetAllBookQueriesReponse>> Handle(GetAllBookQueriesRequest request, CancellationToken cancellationToken)
        {
            var books = await unitOfWork.GetReadReponsitory<Book>().GetAllAsync(x => !x.IsDeleted, include: y => y.Include(b => b.author));
            var Author = mapper.Map<AuthorDtos, Author>(new Domain.Entity.Author());
            var map = mapper.Map<GetAllBookQueriesReponse, Book>(books);
            return map;
        }
    }
}
