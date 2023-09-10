using System;
using Application.Repositories;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Contexts;
using Persistance.Repositories;
using Persistance.Services;

namespace Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceService(this IServiceCollection collection)
        {
            collection.AddDbContext<HRDbContext>(opt => opt.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=HRManangmentDb;"));
            collection.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<HRDbContext>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);
            collection.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            collection.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            collection.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
            collection.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();
            collection.AddScoped<IJobReadRepository, JobReadRepository>();
            collection.AddScoped<IJobWriteRepository, JobWriteRepository>();
            collection.AddScoped<IJobCategoryService, JobCategoryService>();
            collection.AddScoped<IEmployeeJobWriteRepository, EmployeeJobWriteRepository>();
            collection.AddScoped<IEmployeeJobReadRepository, EmployeeJobReadRepository>();
            collection.AddScoped<IEmployeeJobService, EmployeeJobService>();
       
        }
    }
}

