using Microsoft.AspNetCore.Mvc;

namespace Project_3._0.Controllers
{
    [Route("{controller}")]
    public class ServicesController : Controller
    {
        [HttpGet]
        [ActionName("Services")]
        [Route("{action}")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [ActionName("ServicesDitails")]
        [Route("{action}")]
        public IActionResult ServicesDitails()
        {
            return View();
        }
    }
}
