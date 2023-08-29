using System;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Contexts
{
	public class HRDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
		public HRDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Category> Categories { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Job> Jobs { get; set; }
        public DbSet<EmployeeJob> EmployeeJob { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
                builder.Entity<Employee>().HasMany(x => x.Jobs).WithMany(x => x.Employees).UsingEntity<EmployeeJob>();
            base.OnModelCreating(builder);
        }

    }
}

