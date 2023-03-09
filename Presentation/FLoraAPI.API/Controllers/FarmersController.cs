using FloraAPI.Application.Features.Commands.CreateTree;
using FloraAPI.Application.Features.FarmerFeatures.Commands.CreateFarmer;
using FloraAPI.Application.Features.FarmerFeatures.Queries.GetFarmer;
using FloraAPI.Application.Features.FarmerFeatures.Queries.GetFarmerById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FLoraAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmersController : ControllerBase
    {

        IMediator _mediator;

        public FarmersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetFarmerRequest request= new GetFarmerRequest();
            GetFarmerResponse response= await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetFarmerByIdRequest request)
        {
            GetFarmerByIdResponse response= await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateFarmerRequest request)
        {
            CreateFarmerResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
