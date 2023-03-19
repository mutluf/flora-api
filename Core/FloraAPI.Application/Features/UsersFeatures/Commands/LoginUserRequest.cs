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

namespace FloraAPI.Application.Features.UsersFeatures.Commands
{
    public class LoginUserRequest : IRequest<LoginUserResponse>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        readonly UserManager<User> _userManager;
        readonly SignInManager<User> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public LoginUserHandler(UserManager<User> userManager, SignInManager<User> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }


        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {

            User user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateToken(20);
                return new()
                {
                    Token = token,
                    Message = "Giriş başarılı"
                };
            }
            else
            {
                return new()
                {
                    Message = "Yeniden dene"
                };
            }
        }
            
        }
}

public class LoginUserResponse
{
    public string Message { get; set; }
    public Token Token { get; set; }
}

