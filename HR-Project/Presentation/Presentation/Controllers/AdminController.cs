using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.Commands.Category.CreateCategory;
using Application.CQRS.Commands.Job.CreateJob;
using Application.Repositories;
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
        public AdminController(IMediator mediator,ICategoryReadRepository categoryReadRepository)
        {
            _mediator = mediator;
            _categoryReadRepository = categoryReadRepository;
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
            return RedirectToAction("GetJob", "Job");
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

    }
}

