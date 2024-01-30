using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Auth.Contracts;
using Restaurant.Auth.UseCases.Users.Commands;
using Restaurant.Auth.UseCases.Users.Commands.AddUser;
using Restaurant.Auth.UseCases.Users.Queries.GetAllUsers;
using Restaurant.Auth.UseCases.Users.Queries.GetUserById;
using Restaurant.Auth.UseCases.Users.Queries.GetUserByName;

namespace Restaurant.Auth.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IAsyncEnumerable<UserDto> GetAll()
        {
            return _mediator.CreateStream(new GetAllUsersQuery());
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(result);
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            var result = await _mediator.Send(new GetUsersByNameQuery(name));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserModel model)
        {
            var result = await _mediator.Send(new AddUserCommand(model));
            return Ok(result);
        }
    }
}
