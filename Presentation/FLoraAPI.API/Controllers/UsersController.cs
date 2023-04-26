using FloraAPI.Application.Features.UsersFeatures.Commands.CreateUser;
using FloraAPI.Application.Features.UsersFeatures.Commands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FLoraAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;
       
        readonly IConfiguration _configuration;
        public UsersController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserRequest request)
        {
            CreateUserResponse response =await _mediator.Send(request);
            return Ok(response);
        }
    
        [HttpPost("[action]")]
        public async Task<IActionResult> LoginUser(LoginUserRequest request)
        {
            LoginUserResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
