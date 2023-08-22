using System;
using MediatR;

namespace Application.CQRS.Commands.User.SignOutUser
{
	public class SignOutCommandRequest : IRequest<SignOutCommandResponse>
	{
		public SignOutCommandRequest()
		{
		}
	}
}

