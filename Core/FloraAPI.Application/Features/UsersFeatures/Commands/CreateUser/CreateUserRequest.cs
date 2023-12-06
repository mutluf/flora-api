using AutoMapper;
using FloraAPI.Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FloraAPI.Application.Features.UsersFeatures.Commands.CreateUser
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        
        public string Password { get; set; }


    }
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        readonly UserManager<User> _userManager;
        readonly IMapper _mapper;
     
        public CreateUserHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {

            User user = _mapper.Map<User>(request);
            IdentityResult result = await _userManager.CreateAsync(user,request.Password);

            List<string> errors = new List<string>();

            foreach (var error in result.Errors)
            {
                errors.Add(error.Description);
            }

            if (result.Succeeded)
            {
                return new()
                {
                    Message = "kayıt başarılı!"

                };
            }
            else
            {
                
                return new()
                {

                   Errors= errors   

                };
            }

            
        }
    }
    public class CreateUserResponse
    {
        public string Message { get; set; }
        public List<string> Errors { get; set; }

    }
}
