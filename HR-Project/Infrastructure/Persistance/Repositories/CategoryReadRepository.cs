using System;
using Application.Repositories;
using Domain.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
	public class CategoryReadRepository : ReadRepository<Category>,ICategoryReadRepository  
	{
		public CategoryReadRepository(HRDbContext context) : base(context)
		{
		}
	}
}

