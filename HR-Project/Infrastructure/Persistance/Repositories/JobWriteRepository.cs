using System;
using System.Runtime.ConstrainedExecution;
using Application.Repositories;
using Domain.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
	public class JobWriteRepository : WriteRepository<Job>, IJobWriteRepository
    {
		public JobWriteRepository(HRDbContext context) : base(context)
        {

		}
	}
}

