using Microsoft.AspNetCore.Mvc;

namespace Project_3._0.Controllers
{
    [Route("{controller}")]
    public class ContactsController : Controller
    {
        [HttpGet]
        [ActionName("Contacts")]
        [Route("{action}")]      
        public IActionResult Index()
        {
            return View();
        }
    }
}
