using System;
using Application.Services;
using Application.ViewModels;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;

namespace Persistance.Services
{
    public class JobCategoryService : IJobCategoryService
    {
        private readonly HRDbContext _context;
        public JobCategoryService(HRDbContext context)
        {
            _context = context;
        }
        public IQueryable<Job_Category_View_Model> GetJobCategory()
        {
            var model = from j in _context.Jobs
                        join c in _context.Categories
            on j.CategoryId equals c.Id
                        select new Job_Category_View_Model
                        {
                           JobId = j.Id,
                           JobName = j.JobName,
                           CategoryName = c.CategoryName,
                           Description = j.Description,
                           Level = j.Level,
                           Type = j.Type,
 
                        };

            return model;
        }
    }
}

