using Application.Features.Authors.Command.Create;
using Application.Features.Authors.Command.Delete;
using Application.Features.Authors.Command.Update;
using Application.Features.Authors.Queries.GetAll;
using Application.Features.Authors.Queries.GetOne;
using Application.Features.Sales.Command.Create;
using Application.Features.Sales.Command.Delete;
using Application.Features.Sales.Command.Update;
using Application.Features.Sales.Queries.GetAll;
using Application.Features.Sales.Queries.GetOne;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        public readonly IMediator mediator;
        private readonly IAuthorizationService authorizationService;
        public SaleController(IMediator mediator, IAuthorizationService authorizationService)
        {
            this.mediator = mediator;
            this.authorizationService = authorizationService;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllSale()
        {
            var response = await mediator.Send(new GetAllQueriesSaleRequest());

            return Ok(response);

        }

        [HttpPost]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateSale([FromForm] CreateCommandSaleRequest requeste)
        {
            await mediator.Send(requeste);

            return Ok();
        }
        [HttpPut("id")]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateSale([FromForm] UpdateCommandSaleRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteSale(DeleteCommandSaleRequest requeste)
        {
            await mediator.Send(requeste);
            return Ok();
        }
        [HttpPost]

        public async Task<IActionResult> GetSaleById(GetByIdQueriesSaleRequest request)
        {
            var reponser = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }

    }
}

