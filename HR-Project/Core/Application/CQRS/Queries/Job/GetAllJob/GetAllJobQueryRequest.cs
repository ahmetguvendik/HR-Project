using System;
using MediatR;

namespace Application.CQRS.Queries.Job.GetAllJob
{
	public class GetAllJobQueryRequest : IRequest<IQueryable<Domain.Entities.Job>>
	{
		
	}
}

