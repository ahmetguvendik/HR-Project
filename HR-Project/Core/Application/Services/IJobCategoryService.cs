using System;
using Application.ViewModels;

namespace Application.Services
{
	public interface IJobCategoryService
	{
        IQueryable<Job_Category_View_Model> GetJobCategory();
    }
}

