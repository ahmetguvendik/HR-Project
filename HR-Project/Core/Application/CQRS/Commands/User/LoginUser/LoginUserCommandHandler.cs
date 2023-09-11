using System;
using Application.Exceptions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application.CQRS.Commands.User.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public LoginUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.FindByNameAsync(request.UserName);
            var response = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if(appUser == null)
            {
                throw new NotFoundUserException();
            }
            if (response.Succeeded)
            {
                var role = await _userManager.GetRolesAsync(appUser);
                if (role.Contains("Member"))
                {
                    return new LoginUserCommandResponse()
                    {
                        Id = appUser.Id,
                        UserName = request.UserName,
                        Password = request.Password,
                        Role = "Member"
                    };
                }

                else if (role.Contains("Admin"))
                {
                    return new LoginUserCommandResponse()
                    {
                        Id = appUser.Id,
                        UserName = request.UserName,
                        Password = request.Password,
                        Role = "Admin"
                    };
                }

            }

            return new LoginUserCommandResponse()
            {
                Id = appUser.Id,
                UserName = request.UserName,
                Password = request.Password,
                Role = ""
            };
        }
    }

}