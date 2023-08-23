using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.Commands.User.CreateUser;
using Application.CQRS.Commands.User.LoginUser;
using Application.CQRS.Commands.User.SignOutUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginUserCommandRequest model)
        {
            var response = await _mediator.Send(model);
            if (response.Role == "Admin")
            {
                return RedirectToAction("GetCar", "Admin");
            }
            else if (response.Role == "Member")
            {
                return RedirectToAction("GetJob", "Job");
            }

            return View(response);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(CreateUserCommandRequest model)
        {
            var response = await _mediator.Send(model);
            return View(response);
        }


        public async Task<IActionResult> SignOut()
        {
            await _mediator.Send(new SignOutCommandRequest());
            return RedirectToAction("SignIn", "User");
        }
    }
}

