using Microsoft.AspNetCore.Mvc;

namespace Project_3._0.Controllers
{
    [Route("{controller}")]
    public class AboutController:Controller
    {
        [HttpGet]
        [ActionName("About")]
        [Route("{action}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
