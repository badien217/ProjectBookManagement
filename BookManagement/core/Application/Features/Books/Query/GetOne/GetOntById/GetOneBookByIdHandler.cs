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

namespace Application.Features.Books.Query.GetOne.GetOntById
{
    public class GetOneBookByIdHandler : BaseHandler, IRequestHandler<GetOneBookByIdRequest, GetOneBookByIdReponse>
    {
        public GetOneBookByIdHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }
        public async Task<GetOneBookByIdReponse> Handle(GetOneBookByIdRequest request, CancellationToken cancellationToken)
        {
            var books = await unitOfWork.GetReadReponsitory<Book>().GetAsync(x => x.Id == request.Id || !x.IsDeleted);
            var map = mapper.Map<GetOneBookByIdReponse, Book>(books);
            return map;

        }
    }
}
