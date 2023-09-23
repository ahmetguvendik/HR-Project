using System;
using Application.ViewModels;
using MediatR;

namespace Application.CQRS.Queries.EmployeeJob.GetAllEmployeeJob
{
	public class GetAllEmployeeJobQueryRequest : IRequest<IQueryable<Employee_Job_ViewModel>>
	{
		
	}
}

