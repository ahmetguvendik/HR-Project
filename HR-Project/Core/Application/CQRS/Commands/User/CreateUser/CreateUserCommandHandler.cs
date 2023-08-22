using System;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.CQRS.Commands.User.CreateUser
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest,CreateUserCommandResponse>
	{
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public CreateUserCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
		{
            _userManager = userManager;
            _roleManager = roleManager;
		}

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = new AppUser();
            user.Id = Guid.NewGuid().ToString();
            user.UserName = request.UserName;
            var response = await _userManager.CreateAsync(user, request.Password);
            if (response.Succeeded)
            {
                var role = await _roleManager.FindByNameAsync("Member");
                if (role == null)
                {
                    var appRole = new AppRole()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Member"

                    };

                    await _roleManager.CreateAsync(appRole);
                }
                await _userManager.AddToRoleAsync(user, "Member");
            }
            return new CreateUserCommandResponse()
            {
                Password = request.Password,
                UserName = request.UserName
            };
        }
    }
}

