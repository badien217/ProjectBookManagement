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

namespace Application.Features.Authors.Command.Create
{
    public class CreateCommandAuthorHandler : BaseHandler, IRequestHandler<CreateCommandAuthorRequest, Unit>
    {
        public CreateCommandAuthorHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }
        public async Task<Unit> Handle(CreateCommandAuthorRequest request, CancellationToken cancellationToken)
        {
            var AuthorNew = new Author { name = request.name, age = request.age, rating = request.rating, avatar = request.avatar };

            await unitOfWork.GetWriteReponsitory<Author>().AddAsync(AuthorNew);
            return Unit.Value;
        }
    }
}
