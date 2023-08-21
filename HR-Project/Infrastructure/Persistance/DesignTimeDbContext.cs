using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Persistance.Contexts;
namespace Persistance
{
	public class DesignTimeDbContext : IDesignTimeDbContextFactory<HRDbContext>
    {
	
        public HRDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<HRDbContext> dbContextOptions = new();
            dbContextOptions.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=HRManangmentDb;");
            return new(dbContextOptions.Options);   
        }
    }
}

