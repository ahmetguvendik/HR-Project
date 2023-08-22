using System;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.CQRS.Commands.User.SignOutUser
{
	public class SignOutCommandHandler : IRequestHandler<SignOutCommandRequest,SignOutCommandResponse>
	{
        private readonly SignInManager<AppUser> _signInManager;
        public SignOutCommandHandler(SignInManager<AppUser> signInManager)
		{
            _signInManager = signInManager;
		}

        public async Task<SignOutCommandResponse> Handle(SignOutCommandRequest request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
            return new SignOutCommandResponse();
        }
    }
}

