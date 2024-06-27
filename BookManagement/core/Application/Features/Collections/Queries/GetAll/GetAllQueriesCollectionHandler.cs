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

namespace Application.Features.Collections.Queries.GetAll
{
    public class GetAllQueriesCollectionHandler : BaseHandler, IRequestHandler<GetAllQueriesCollectionRequest, IList<GetAllQueriesCollectionReponse>>
    {
        public GetAllQueriesCollectionHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllQueriesCollectionReponse>> Handle(GetAllQueriesCollectionRequest request, CancellationToken cancellationToken)
        {
            IList<Collection> collection = await unitOfWork.GetReadReponsitory<Collection>().GetAllAsync(b => !b.IsDeleted,include: x => x.Include(y => y.sale)  );
            var map = mapper.Map<AuthorDtos, Author>(new Author());
            var collectionmap = mapper.Map<GetAllQueriesCollectionReponse, Collection>(collection);
            return collectionmap;
        }
    }
}
