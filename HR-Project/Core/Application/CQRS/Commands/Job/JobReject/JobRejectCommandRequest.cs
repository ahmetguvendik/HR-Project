using System;
using MediatR;

namespace Application.CQRS.Commands.Job.JobReject
{
	public class JobRejectCommandRequest : IRequest<JobRejectCommandResponse>
	{
		public string Id { get; set; }	
	}
}

