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

namespace Application.Features.Ratings.Command.Update
{
    public class UpdateCommandRatingHandler : BaseHandler, IRequestHandler<UpdateCommandRatingRequest, Unit>
    {
        public UpdateCommandRatingHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(UpdateCommandRatingRequest request, CancellationToken cancellationToken)
        {
            var rating = await unitOfWork.GetReadReponsitory<Rating>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            var map = mapper.Map< Rating, UpdateCommandRatingRequest>(request);
            await unitOfWork.GetWriteReponsitory<Rating>().UpdateAsync(map);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
