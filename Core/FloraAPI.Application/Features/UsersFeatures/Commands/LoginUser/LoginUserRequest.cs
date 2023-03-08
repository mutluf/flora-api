using AutoMapper;
using FloraAPI.Application.Abstractions;
using FloraAPI.Application.DTOs;
using FloraAPI.Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloraAPI.Application.Features.UsersFeatures.Commands.LoginUser
{
    public class LoginUserRequest : IRequest<LoginUserResponse>
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        readonly IMapper _mapper;
        readonly UserManager<User> _userManager;
        readonly SignInManager<User> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public LoginUserHandler(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, ITokenHandler tokenHandler)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            //User user = _mapper.Map<User>(request);
            User user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
            if (user==null)
            {
                user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);
            }
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            

            if (result.Succeeded)
            {
                Token token=_tokenHandler.CreateToken(20);
                return new()
                {
                    Message = "Giriş yapıldı.",
                    Token =token
                    
                };
            }
            else
            {
                return new()
                {
                    Message = "yeniden dene"
                };
            }

        }
    }
    public class LoginUserResponse
    {
    
        public string Message { get; set; }
        public Token Token { get; set; }

    }
}
