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

namespace Application.Features.Books.Query.GetOne.GetOneByAuthor
{
    public class GetOneBookByAuthorHandler : BaseHandler, IRequestHandler<GetOneBookByAuthorRequest, IList<GetOneBookByAuthorReponse>>
    {
        public GetOneBookByAuthorHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }
        public async Task<IList<GetOneBookByAuthorReponse>> Handle(GetOneBookByAuthorRequest request, CancellationToken cancellationToken)
        {
            var books = await unitOfWork.GetReadReponsitory<Book>().Find(x => x.AuthorId == request.AuthorId);
            var map = mapper.Map<GetOneBookByAuthorReponse, Book>(books);
        }
    }
}
