using System;
using Application.Repositories;
using Domain.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
	public class EmployeeJobReadRepository : ReadRepository<EmployeeJob>, IEmployeeJobReadRepository
    {
		public EmployeeJobReadRepository(HRDbContext context) : base(context)
        {
		}
	}
}

