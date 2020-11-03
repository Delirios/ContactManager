using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ContactManager.Queries;
using ContactManager.Commands;

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
            return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
