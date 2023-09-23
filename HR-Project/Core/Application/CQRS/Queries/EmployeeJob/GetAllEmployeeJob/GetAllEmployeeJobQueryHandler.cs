using System;
using Application.Services;
using Application.ViewModels;
using MediatR;

namespace Application.CQRS.Queries.EmployeeJob.GetAllEmployeeJob
{
	public class GetAllEmployeeJobQueryHandler : IRequestHandler<GetAllEmployeeJobQueryRequest,IQueryable<Employee_Job_ViewModel>>
	{
        private readonly IEmployeeJobService _employeeJobService;
		public GetAllEmployeeJobQueryHandler(IEmployeeJobService employeeJobService)
		{
            _employeeJobService = employeeJobService;
		}

        public async Task<IQueryable<Employee_Job_ViewModel>> Handle(GetAllEmployeeJobQueryRequest request, CancellationToken cancellationToken)
        {
            var response = _employeeJobService.GetEmployeeJob();
            return response;
        }
    }
}

