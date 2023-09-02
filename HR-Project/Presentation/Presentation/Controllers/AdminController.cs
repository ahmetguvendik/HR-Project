using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.Commands.Category.CreateCategory;
using Application.CQRS.Commands.Job.CreateJob;
using Application.CQRS.Commands.Job.RemoveJob;
using Application.Repositories;
using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    public class AdminController : Controller
    {
        // GET: /<controller>/
        private readonly IMediator _mediator;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IJobCategoryService _jobCategoryService;
        public AdminController(IMediator mediator,ICategoryReadRepository categoryReadRepository,IJobCategoryService jobCategoryService)
        {
            _mediator = mediator;
            _categoryReadRepository = categoryReadRepository;
            _jobCategoryService = jobCategoryService;
        }
        public IActionResult CreateJob()
        {

            var categories = _categoryReadRepository.GetAll();
            List<SelectListItem> values = (from c in categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = c.CategoryName,
                                               Value = c.Id.ToString()

                                           }).ToList();

            ViewBag.Categories = values;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob(CreateJobCommandRequest model)
        {
             await _mediator.Send(model);
            return RedirectToAction("GetJob", "Admin");
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest model)
        {
            var response = await _mediator.Send(model);
            return View(response);
        }

        public IActionResult GetJob()
        {
            var values = _jobCategoryService.GetJobCategory();
            return View(values);
        }

        public async Task<IActionResult> RemoveJob(string id)
        {
            var response = new RemoveJobCommandRequest();
            response.Id = id;
            await _mediator.Send(response);
            return RedirectToAction("GetJob", "Admin");
        }
    }
}

