using Application.Features.Books.Command.Create;
using Application.Features.Books.Command.Delete;
using Application.Features.Books.Command.Update;
using Application.Features.Books.Query.GetAll;
using Application.Features.Books.Query.GetOne.GetOneByAuthor;
using Application.Features.Books.Query.GetOne.GetOntById;
using Application.Features.Books.Query.GetTotal;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly IMediator mediator;
        private readonly IAuthorizationService authorizationService;
        public BookController(IMediator mediator, IAuthorizationService authorizationService)
        {
            this.mediator = mediator;
            this.authorizationService = authorizationService;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllBook()
        {
            var response = await mediator.Send(new GetAllBookQueriesRequest());

            return Ok(response);

        }

        [HttpPost]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateBook([FromForm] CreateBookCommandRequest requeste)
        {
            await mediator.Send(requeste);

            return Ok();
        }
        [HttpPut("id")]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateBook([FromForm] UpdateBookCommandRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteBook(DeleteBookCommandRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]

        public async Task<IActionResult> GetBookById(GetOneBookByIdRequest request)
        {
            var reponser = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }
        [HttpPost]

        public async Task<IActionResult> GetBookByAuhor(GetOneBookByAuthorRequest request)
        {
            var reponser = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }
        [HttpGet]

        public async Task<IActionResult> GetTotalBook()
        {
            var response = await mediator.Send(new GetTotalBookRequest());
            return Ok(response);
        }


    }
}
