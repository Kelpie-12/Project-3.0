using Microsoft.AspNetCore.Mvc;

namespace Project_3._0.Controllers
{
    [Route("{controller}")]
    public class HomeController : Controller
    {
        [HttpGet]
        [ActionName("Home")]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
