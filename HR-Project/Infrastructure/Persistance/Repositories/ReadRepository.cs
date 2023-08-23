using System;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
		private readonly HRDbContext _context;
		public ReadRepository(HRDbContext context)
		{
			_context = context;
		}

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
        {
            return Table.AsNoTracking();
        }

        public async Task<T> GetById(string id)
        {
            return await Table.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

