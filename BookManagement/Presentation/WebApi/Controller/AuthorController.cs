using Application.Features.Authors.Command.Create;
using Application.Features.Authors.Command.Delete;
using Application.Features.Authors.Command.Update;
using Application.Features.Authors.Queries.GetAll;
using Application.Features.Authors.Queries.GetOne;
using Application.Features.Books.Command.Create;
using Application.Features.Books.Command.Delete;
using Application.Features.Books.Command.Update;
using Application.Features.Books.Query.GetAll;
using Application.Features.Books.Query.GetOne.GetOneByAuthor;
using Application.Features.Books.Query.GetOne.GetOntById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public readonly IMediator mediator;
        private readonly IAuthorizationService authorizationService;
        public AuthorController(IMediator mediator, IAuthorizationService authorizationService)
        {
            this.mediator = mediator;
            this.authorizationService = authorizationService;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllAuthor()
        {
            var response = await mediator.Send(new GetAllQueriesAuthorRequest());

            return Ok(response);

        }

        [HttpPost]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateAuthor(CreateCommandAuthorRequest requeste)
        {
            await mediator.Send(requeste);

            return Ok();
        }
        [HttpPost]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateBook( UpdateCommandAuthorRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteAuthor(DeleteCommandAuthorRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]

        public async Task<IActionResult> GetAuthorbyId(GetByIdQueriesAuthorRequest request)
        {
            var reponser = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }
       
    }
}
