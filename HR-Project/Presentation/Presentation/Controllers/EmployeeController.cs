using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.Commands.Employee.CreateEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;       
        }

        [HttpPost]
        public async Task<IActionResult> ApplyJob(CreateEmployeeCommandRequest model)
        {
            var response = await _mediator.Send(model);
            return View(response);
        }

        public async Task<IActionResult> ApplyJob(string id)
        {
            var response = new CreateEmployeeCommandResponse();
            response.JobId = id;
            return View(response);
        }
    }
}

