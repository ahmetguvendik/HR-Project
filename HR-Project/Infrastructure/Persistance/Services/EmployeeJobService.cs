using System;
using Application.Repositories;
using Application.Services;
using Application.ViewModels;
using Persistance.Contexts;

namespace Persistance.Services
{
	public class EmployeeJobService : IEmployeeJobService
	{
        private readonly HRDbContext _context;
        private readonly IEmployeeJobReadRepository _employeeJobReadRepository;
		public EmployeeJobService(HRDbContext context, IEmployeeJobReadRepository employeeJobReadRepository)
		{
            _context = context;
            _employeeJobReadRepository = employeeJobReadRepository;
		}

        public IQueryable<Employee_Job_ViewModel> GetEmployeeJob()
        {
            var model = from j in _context.Jobs
                        join ej in _context.EmployeeJob
            on j.Id equals ej.JobId
                        join e in _context.Employees
             on ej.EmployeeId equals e.Id
                        select new Employee_Job_ViewModel
                        {
                           Id = ej.Id,
                           EmployeeName = e.Name,
                           JobName = j.JobName,
                           EmployeeSurname = e.Surname,
                           IsOk = ej.IsOk,
                           IsRed = ej.IsRed
                           
                        };

            return model;
        }


    }
}

