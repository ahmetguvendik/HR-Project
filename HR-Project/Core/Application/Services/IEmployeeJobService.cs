using System;
using Application.ViewModels;

namespace Application.Services
{
	public interface IEmployeeJobService
	{
        IQueryable<Employee_Job_ViewModel> GetEmployeeJob();
        IQueryable<Employee_Job_ViewModel> GetEmployeeJobById(string id);
    }
}

