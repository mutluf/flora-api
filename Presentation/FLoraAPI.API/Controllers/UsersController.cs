using FloraAPI.Application.Features.UsersFeatures.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FLoraAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserRequest request)
        {
            CreateUserResponse response =await _mediator.Send(request);
            return Ok(response);
        }

        public async Task<IActionResult> LoginUser(LoginUserRequest request)
        {
            LoginUserResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
