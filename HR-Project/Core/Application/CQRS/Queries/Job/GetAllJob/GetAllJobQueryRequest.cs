using System;
using Application.ViewModels;
using MediatR;

namespace Application.CQRS.Queries.Job.GetAllJob
{
	public class GetAllJobQueryRequest : IRequest<IQueryable<Job_Category_View_Model>>
	{
		
	}
}

