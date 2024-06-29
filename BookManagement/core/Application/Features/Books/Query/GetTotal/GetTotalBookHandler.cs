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

namespace Application.Features.Books.Query.GetTotal
{
    public class GetTotalBookHandler : BaseHandler, IRequestHandler<GetTotalBookRequest,long>
    {
        public GetTotalBookHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<long> Handle(GetTotalBookRequest request, CancellationToken cancellationToken)
        {
            var book = await unitOfWork.GetReadReponsitory<Book>().GetAllAsync(x => !x.IsDeleted);
            long count = book.Count;
            return count;
        }
    }
}
