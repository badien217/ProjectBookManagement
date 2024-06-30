using Application.Features.Authors.Command.Create;
using Application.Features.Authors.Command.Delete;
using Application.Features.Authors.Command.Update;
using Application.Features.Authors.Queries.GetAll;
using Application.Features.Authors.Queries.GetOne;
using Application.Features.Faqs.Command.create;
using Application.Features.Faqs.Command.delete;
using Application.Features.Faqs.Command.update;
using Application.Features.Faqs.Queries.GetAll;
using Application.Features.Faqs.Queries.GetOne;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FaqController : ControllerBase
    {

        public readonly IMediator mediator;
        private readonly IAuthorizationService authorizationService;
        public FaqController(IMediator mediator, IAuthorizationService authorizationService)
        {
            this.mediator = mediator;
            this.authorizationService = authorizationService;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllFaq()
        {
            var response = await mediator.Send(new GetAllFaqRequest());

            return Ok(response);

        }

        [HttpPost]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateFaq([FromForm] CreateCommandFaqRequest requeste)
        {
            await mediator.Send(requeste);

            return Ok();
        }
        [HttpPut("id")]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateFaq([FromForm] UpdateCommandFaqRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteFaq(DeleteCommandFaqRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]

        public async Task<IActionResult> GetFaqById(GetOneQueriesFaqRequest request)
        {
            var reponser = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }

    }
}
