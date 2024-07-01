
using Application.Features.Orders.Command.Create;
using Application.Features.Orders.Command.Delete;
using Application.Features.Orders.Command.Update;
using Application.Features.Orders.Queries.GetAll;
using Application.Features.Orders.Queries.GetOne;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly IMediator mediator;
        private readonly IAuthorizationService authorizationService;
        public OrderController(IMediator mediator, IAuthorizationService authorizationService)
        {
            this.mediator = mediator;
            this.authorizationService = authorizationService;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllOrder()
        {
            var response = await mediator.Send(new GetAllQueriesOrderRequest());

            return Ok(response);

        }

        [HttpPost]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateOrder([FromForm] CreateCommadOrderRequest requeste)
        {
            await mediator.Send(requeste);

            return Ok();
        }
        [HttpPost]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateOrder([FromForm] UpdateCommandOrderRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteOrder(DeleteCommandOrderRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]

        public async Task<IActionResult> GetOrderById(GetOrderByIdRequest request)
        {
            var reponser = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }
    }
}
