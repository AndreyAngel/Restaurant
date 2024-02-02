using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Auth.UseCases.Auth.Commands.Authorization;
using Restaurant.Auth.UseCases.Auth.Commands.Registration;

namespace Restaurant.Auth.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthorizationCommand request)
        {
            var result = await _mediator.Send(request);

            if (result.IsNullOrEmpty())
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
