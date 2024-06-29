using Application.Base;
using Application.Interfaces.AutoMapping;
using Application.Interfaces.UnitOfWork;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ratings.Command.Delete
{
    public class DeleteCommandRatingHandler : BaseHandler, IRequestHandler<DeleteCommandRatingRequest, Unit>
    {
        public DeleteCommandRatingHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(DeleteCommandRatingRequest request, CancellationToken cancellationToken)
        {
            var rating = await unitOfWork.GetReadReponsitory<Rating>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            rating.IsDeleted = true;
            await unitOfWork.GetWriteReponsitory<Rating>().UpdateAsync(rating);
            await unitOfWork.SaveAsync();
            return Unit.Value;
                 
        }
    }
}
