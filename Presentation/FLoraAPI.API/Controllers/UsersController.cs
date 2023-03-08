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
        #region yorum
        //bize bu türde bir request gelmiş, ama nasıl gelmiş body route ?body olmadığı kesin demek istiyorum ama yapılacak işlemi bildiğim için body cevPP YANİ body tamam ama json ddin ben ortada jsonlık bir durum görmüyorum  tamam anlaştık balım ben bir su geliyooommmya gittim aslında yatak almaya gittiğimde de onu da söylemeyeyim yani dedim iyi anlaşıldıok, doki balımmmmmmmmmmmmmmmm teşşekkürler canım ben daha çok seviyorums izi<3 sensin ellerinize sağlık derim girmeyelim hani  yok bildiğim yok yok tmamdır sen atıver bana <3 şu an olmaaaaz aleyna bana dönük tamam <3 hazırımmmmmmmm tamam
        #endregion
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
