using System;
using MediatR;

namespace Application.CQRS.Commands.Job.JobConfirm
{
	public class JobConfirmCommandRequest : IRequest<JobConfirmCommandResponse>
	{
		public string Id { get; set; }
    }
}

