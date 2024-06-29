using Application.Features.Authors.Command.Create;
using Application.Features.Authors.Command.Delete;
using Application.Features.Authors.Command.Update;
using Application.Features.Authors.Queries.GetAll;
using Application.Features.Collections.Command.Create;
using Application.Features.Collections.Command.Delete;
using Application.Features.Collections.Command.Update;
using Application.Features.Collections.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        public readonly IMediator mediator;
        private readonly IAuthorizationService authorizationService;
        public CollectionController(IMediator mediator, IAuthorizationService authorizationService)
        {
            this.mediator = mediator;
            this.authorizationService = authorizationService;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllCollection()
        {
            var response = await mediator.Send(new GetAllQueriesCollectionRequest());

            return Ok(response);

        }

        [HttpPost]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateCollection([FromForm] CreateCommandCollectionRequest requeste)
        {
            await mediator.Send(requeste);

            return Ok();
        }
        [HttpPut("id")]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateCollection([FromForm] UpdateCommandCollectionRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteCollection(DeleteCommandCollectionRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
    }
}
