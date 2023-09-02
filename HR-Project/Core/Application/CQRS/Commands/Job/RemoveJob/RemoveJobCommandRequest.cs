using System;
using MediatR;

namespace Application.CQRS.Commands.Job.RemoveJob
{
	public class RemoveJobCommandRequest : IRequest<RemoveJobCommandResponse>
	{
		public string Id { get; set; }	
	}
}

