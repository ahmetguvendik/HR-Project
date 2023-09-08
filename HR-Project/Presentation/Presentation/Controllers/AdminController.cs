using Application.CQRS.Commands.Category.CreateCategory;
using Application.CQRS.Commands.Job.CreateJob;
using Application.CQRS.Commands.Job.JobConfirm;
using Application.CQRS.Commands.Job.JobReject;
using Application.CQRS.Commands.Job.RemoveJob;
using Application.CQRS.Commands.Job.UpdateJob;
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
        private readonly IJobReadRepository _jobReadRepository;
        private readonly IJobCategoryService _jobCategoryService;
        private readonly IEmployeeJobService _employeeJobService;
        public AdminController(IMediator mediator,ICategoryReadRepository categoryReadRepository,IJobCategoryService jobCategoryService,IJobReadRepository jobReadRepository,IEmployeeJobService employeeJobService)
        {
            _mediator = mediator;
            _categoryReadRepository = categoryReadRepository;
            _jobCategoryService = jobCategoryService;
            _jobReadRepository = jobReadRepository;
            _employeeJobService = employeeJobService;
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

        public async Task<IActionResult> UpdateJob(string id)
        {
            var categories = _categoryReadRepository.GetAll();
            List<SelectListItem> values = (from c in categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = c.CategoryName,
                                               Value = c.Id.ToString()

                                           }).ToList();

            ViewBag.Categories = values;
            var job = await _jobReadRepository.GetById(id);
            var jobMapper = new UpdateJobCommandResponse();
            jobMapper.CategoryId = job.CategoryId;
            jobMapper.Description = job.Description;
            jobMapper.JobName = job.JobName;
            jobMapper.Level = job.Level;
            jobMapper.Type = job.Type;
            return View(jobMapper);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateJob(UpdateJobCommandRequest model)
        {
            await _mediator.Send(model);
            return RedirectToAction("GetJob","Admin");
        }

        public IActionResult GetEmployeeJob()
        {
            var value = _employeeJobService.GetEmployeeJob();
            return View(value);
        }

        public async Task<IActionResult> SendOk(JobConfirmCommandRequest model)
        {
            var response = await _mediator.Send(model);
            return RedirectToAction("GetEmployeeJob","Admin");
        }

        public async Task<IActionResult> SendRed(JobRejectCommandRequest model)
        {
            var response = await _mediator.Send(model);
            return RedirectToAction("GetEmployeeJob", "Admin");
        }
    }
}

