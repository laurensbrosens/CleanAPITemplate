using Core.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Core.Users.Queries;
using Core.Users.Commands;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("{fingerprint}")]
        [HttpGet]
        public async Task<IActionResult> GetUser(string fingerprint)
        {
            return Ok(await mediator.Send(new GetUsersByFingerprintQuery(fingerprint)));
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            await mediator.Send(new AddUserCommand(user));
            return Created("", user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {

            var u = await mediator.Send(new UpdateUserCommand(user));
            if (u == null) return NotFound("");
            return Ok(u);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var u = await mediator.Send(new DeleteUserCommand(id));
            return NotFound();
        }
    }
}
