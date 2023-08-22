using System;
using System.Runtime.ConstrainedExecution;
using Application.Repositories;
using Domain.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
	public class EmployeeWriteRepository : WriteRepository<Employee>, IEmployeeWriteRepository
    {
		public EmployeeWriteRepository(HRDbContext context) : base(context)
        {
		}
	}
}

