using System;
namespace Application.CQRS.Queries.Job.GetAllJob
{
	public class GetAllJobQueryResponse
	{
		public IQueryable<Domain.Entities.Job> Jobs { get; set; }	
	}
}

