using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ContactManager.Queries;
using ContactManager.Commands;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using ContactManager.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetUsersQuery();
            var result = await _mediator.Send(query);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserCommand command)
        {
            var result = await _mediator.Send(command);   
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand command)
        {
            var result = await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int userId)
        {
            var query = new GetUserByIdQuery(userId);
            var result = await _mediator.Send(query);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(command);
                return RedirectToAction("Index");
            }
            else
            {
                var query = new GetUserByIdQuery(command.UserId);
                var result = await _mediator.Send(query);
                return View( new User
                {
                    UserId = result.UserId,
                    Name = result.Name,
                    DateOfBirth = result.DateOfBirth,
                    Married = result.Married,
                    Phone = result.Phone,
                    Salary = result.Salary
                });
            }
        }
    }
}
