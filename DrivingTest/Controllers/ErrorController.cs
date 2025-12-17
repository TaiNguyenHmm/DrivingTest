using Microsoft.AspNetCore.Mvc;

namespace DrivingTest.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public IActionResult Blocked()
        {
            return View();
        }
    }
}
