using FloraAPI.Application.Features.Commands.CreateTree;
using FloraAPI.Application.Features.Commands.UpdateTree;
using FloraAPI.Application.Features.TreeFeatures.Commands;
using FloraAPI.Application.Features.TreeFeatures.Queries.GetTree;
using FloraAPI.Application.Features.TreeFeatures.Queries.GetTreeById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FLoraAPI.API.Controllers
{
    [Route("api/trees")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class TreesController : ControllerBase
    {
        IMediator _mediator;

        public TreesController(IMediator mediator)
        {           
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get() { 
            GetTreeRequest request = new GetTreeRequest();  
            GetTreeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTreeRequest tree)
        {
            CreateTreeResponse response= await _mediator.Send(tree);
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTreeRequest tree)
        {
            UpdateTreeResponse response = await _mediator.Send(tree);
            return Ok(response);
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTreeById([FromRoute] GetTreeByIdRequest request)
        {
            GetTreeByIdResponse response = await _mediator.Send(request);
            return Ok(response);   
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTree([FromRoute] DeleteTreeRequest request)
        {
            DeleteTreeResponse response= await _mediator.Send(request);
            return Ok(response);
        }

    }
}
