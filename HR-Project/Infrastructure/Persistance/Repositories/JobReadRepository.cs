using System;
using System.Runtime.ConstrainedExecution;
using Application.Repositories;
using Domain.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
	public class JobReadRepository : ReadRepository<Job>, IJobReadRepository
    {
		public JobReadRepository(HRDbContext context) : base(context)
        {
		}
	}
}

