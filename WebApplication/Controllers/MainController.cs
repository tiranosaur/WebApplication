using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class MainController : Controller
    {
        [HttpGet]
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}