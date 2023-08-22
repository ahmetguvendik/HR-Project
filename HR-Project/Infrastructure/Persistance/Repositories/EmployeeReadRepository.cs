using System;
using Application.Repositories;
using Domain.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
	public class EmployeeReadRepository : ReadRepository<Employee>,IEmployeeReadRepository
    {
		public EmployeeReadRepository(HRDbContext context) : base(context)
        {
		}
	}
}

