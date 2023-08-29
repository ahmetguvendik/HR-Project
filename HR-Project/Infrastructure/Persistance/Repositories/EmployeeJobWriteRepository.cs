using System;
using Application.Repositories;
using Domain.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
	public class EmployeeJobWriteRepository : WriteRepository<EmployeeJob>, IEmployeeJobWriteRepository
    {
		public EmployeeJobWriteRepository(HRDbContext context) : base(context)
        {
		}
	}
}

