using Application.CQRS.Commands.Employee.CreateEmployee;
using Application.Repositories;
using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IEmployeeJobReadRepository _employeeJobReadRepository;
        private readonly IEmployeeReadRepository _employeeReadRepository;
        private readonly IEmployeeJobService _employeeJobService;
        public EmployeeController(IMediator mediator,IEmployeeJobReadRepository employeeJobReadRepository,IEmployeeReadRepository employeeReadRepository,IEmployeeJobService employeeJobService)
        {
            _mediator = mediator;
            _employeeJobReadRepository = employeeJobReadRepository;
            _employeeReadRepository = employeeReadRepository;
            _employeeJobService = employeeJobService;
        }

        [HttpPost]
        public async Task<IActionResult> ApplyJob(CreateEmployeeCommandRequest model)
        {
            var response = await _mediator.Send(model);
            return View(response);
        }

        public async Task<IActionResult> ApplyJob(string id)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var response = new CreateEmployeeCommandResponse();
            response.JobId = id;
            response.UserId = userId;
            return View(response);
        }

        public async Task<IActionResult> GetApplication()
        {
            var id = HttpContext.Session.GetString("UserId");
            var value = _employeeJobService.GetEmployeeJobById(id);
            return View(value);
        }
    }
}

