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

namespace Application.Features.Ratings.Command.Create
{
    public class CreateCommandRatingHandler : BaseHandler, IRequestHandler<CreateCommandRatingRequest,Unit>
    {
        public CreateCommandRatingHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateCommandRatingRequest request, CancellationToken cancellationToken)
        {
            var rating = new Rating { comment = request.comment,rating = request.rating,bookId = request.bookId,userProfileId = request.userProfileId };
            await unitOfWork.GetWriteReponsitory<Rating>().AddAsync(rating);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
