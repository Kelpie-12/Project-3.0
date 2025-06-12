using Microsoft.AspNetCore.Mvc;
using Project_3._0.Model.Domain;
using Project_3._0.Services.Implementation;

namespace Project_3._0.Controllers
{
    [Route("{controller}")]
    public class HomeController : Controller
    {
        private readonly IApartmentServices _apartmentServices;
        public HomeController(IApartmentServices apartmentServices)
        {
            _apartmentServices = apartmentServices;
        }
        [HttpGet]
        [ActionName("Home")]
        [Route("/")]
        public IActionResult Index()
        {
            List<Apartment> apartments = _apartmentServices.GetAll();
            return View(apartments);
        }
    }
}
