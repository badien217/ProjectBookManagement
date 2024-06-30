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

namespace Application.Features.Ratings.Queries.GetRating.GetRatingByAuthor
{
    public class GetRatingByAuthorHandler : BaseHandler, IRequestHandler<GetRatingByAuthorRequest, GetRatingByAuthorReponse>
    {
        public GetRatingByAuthorHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<GetRatingByAuthorReponse> Handle(GetRatingByAuthorRequest request, CancellationToken cancellationToken)
        {
            var rating = await unitOfWork.GetReadReponsitory<Rating>().GetAsync(x => x.userProfileId == request.IdAuthor && !x.IsDeleted,
                include: y => y.Include(b => b.book).Include(k => k.userProfile));
            var map1 = mapper.Map<BookDtos, Book>(new Book());
            var map2 = mapper.Map<UserProfileDtos, UserProfile>(new UserProfile());
            var map = mapper.Map<GetRatingByAuthorReponse, Rating>(rating);
            return map;
            
        }
    }
}
