using Application.Features.Authors.Command.Create;
using Application.Features.Authors.Command.Delete;
using Application.Features.Authors.Command.Update;
using Application.Features.Authors.Queries.GetAll;
using Application.Features.Authors.Queries.GetOne;
using Application.Features.Ratings.Command.Create;
using Application.Features.Ratings.Command.Delete;
using Application.Features.Ratings.Command.Update;
using Application.Features.Ratings.Queries.GetRating.GetRatingByAuthor;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        public readonly IMediator mediator;
        private readonly IAuthorizationService authorizationService;
        public RatingController(IMediator mediator, IAuthorizationService authorizationService)
        {
            this.mediator = mediator;
            this.authorizationService = authorizationService;
        }
   

        [HttpPost]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateRating([FromForm] CreateCommandRatingRequest requeste)
        {
            await mediator.Send(requeste);

            return Ok();
        }
        [HttpPost]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateRating([FromForm] UpdateCommandRatingRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteRating(DeleteCommandRatingRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]

        public async Task<IActionResult> GetRatingById(GetRatingByAuthorRequest request)
        {
            var reponser = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }
    }
}
