using FloraAPI.Application.Features.TreeFeatures.Commands;
using FloraAPI.Application.Features.TreeFeatures.Queries;
using FloraAPI.Application.Repositories.TreeRepository;
using FloraAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FLoraAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreesController : ControllerBase
    {
        IMediator _mediator;

        public TreesController(IMediator mediator)
        {           
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()//get yaparken model parametre almayacağız
        {//bu kadar balım. Get için hiç parametre olmaz genelde, getbyid id alır, getwhere başka bir koşul için veriler alır ama bunların hiçbiri body'den mdeol taşıyarak olmaz.
            GetTreeRequest request = new GetTreeRequest();  //böyle olabilir emin değilim ama bakarız.
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

        [HttpGet("{Id}")]//normalde cqrs yokken, böyle yapardık ya [FromRoute] string Id şeklinde süslü içindeki isimle aynı olacaktı. şimdi de model veriyoruz ve o modelin içindeki isim aynı olsun ki onları birbiriyle bağlasın. query alacaksak query ama şu an route gidiyoruz. 
        public async Task<IActionResult> GetTreeById([FromRoute] GetTreeByIdRequest request)
        {
            GetTreeByIdResponse response = await _mediator.Send(request);
            return Ok(response);   
        }

    }
}
