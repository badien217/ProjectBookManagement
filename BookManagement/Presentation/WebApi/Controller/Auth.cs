using Application.Features.Auths.Commands.Login;
using Application.Features.Auths.Commands.RefreshToken;
using Application.Features.Auths.Commands.Register;
using Application.Features.Auths.Commands.RegisterAdmin;
using Application.Features.Auths.Commands.Revoke;
using Application.Features.Auths.Commands.RevokeAll;
using Application.Features.Auths.Queries.GetProfileUser;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Auths : ControllerBase
    {
        private readonly IMediator mediator;
        public Auths(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AuthRegister(RegisterCommandRequest requeste)
        {
            await mediator.Send(requeste);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        public async Task<IActionResult> AuthRegisterAdmin(RegisterAdminCommandRequest requeste)
        {
            await mediator.Send(requeste);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        public async Task<IActionResult> login(LoginCommandRequest requeste)
        {
            var reponser = await mediator.Send(requeste);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }
        [HttpPost]
        public async Task<IActionResult> refrestoken(RefreshTokenCommandRequest requeste)
        {
            var reponser = await mediator.Send(requeste);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }
        [HttpPost]
        public async Task<IActionResult> getid(GetProfileQueriesRequest requeste)
        {
            var reponser = await mediator.Send(requeste);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            if (!Request.Headers.TryGetValue("Authorization", out var headerValues))
            {
                return Unauthorized();
            }

            var token = headerValues.FirstOrDefault()?.Split(' ').LastOrDefault(); // Extract token from Bearer format
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(new { message = "Thành công" });
        }
        [HttpPost]
        public async Task<IActionResult> Revoke(RevokeCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeAll()
        {
            await mediator.Send(new RevokeAllCommandRequest());
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
