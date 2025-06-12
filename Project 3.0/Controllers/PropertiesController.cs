using Microsoft.AspNetCore.Mvc;

namespace Project_3._0.Controllers
{
    [Route("{controller}")]
    public class PropertiesController : Controller
    {
        [HttpGet]
        [ActionName("Properties")]
        [Route("{action}")]
        public IActionResult Index()
        {
            ViewBag.Object = "Объекты";
            return View();
        }
        [HttpGet]
        [ActionName("PropertiesSingle")]
        [Route("{action}")]
        public IActionResult PropertiesSingle(int? id)
        {
            
            return View();
        }
    }
}
