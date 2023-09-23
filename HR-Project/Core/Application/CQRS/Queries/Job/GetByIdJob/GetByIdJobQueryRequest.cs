using System;
using MediatR;

namespace Application.CQRS.Queries.Job.GetByIdJob
{
	public class GetByIdJobQueryRequest : IRequest<Domain.Entities.Job>
	{
		public string Id { get; set; }
	}
}

