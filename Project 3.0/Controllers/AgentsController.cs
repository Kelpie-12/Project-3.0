using Microsoft.AspNetCore.Mvc;

namespace Project_3._0.Controllers
{
    [Route("{controller}")]
    public class AgentsController : Controller
    {
        [HttpGet]
        [ActionName("Agents")]
        [Route("{action}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
