using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistance.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        private readonly IJobCategoryService _jobCategoryService;
        private readonly IJobReadRepository _jobReadRepository;
        public JobController(IJobCategoryService jobCategoryService,IJobReadRepository jobReadRepository)
        {
            _jobCategoryService = jobCategoryService;
            _jobReadRepository = jobReadRepository;
        }
        public IActionResult GetJob()
        {
            var values = _jobCategoryService.GetJobCategory();
            return View(values);
        }

        public async Task<IActionResult> JobDetail(string id)
        {
            var value = await _jobReadRepository.GetById(id);
            return View(value);
        }
    }
}

