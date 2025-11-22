using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_3._0.Data.Repositories;
using Project_3._0.Model.Domain;
using Project_3._0.Model.View;
using Project_3._0.Services;
using Project_3._0.Services.Implementation;

namespace Project_3._0.Controllers
{
    [Route("{controller}")]
    public class HomeController : Controller
    {
        private readonly IApartmentServices _apartmentServices;
        private readonly IAgentServices _agentServices;
        private readonly IReviewServices _reviewServices;
        public HomeController(IApartmentServices apartmentServices, IAgentServices agentServices, IReviewServices reviewServices)
        {
            _apartmentServices = apartmentServices;
            _agentServices = agentServices;
            _reviewServices = reviewServices;
        }
        [HttpGet]
        [ActionName("Home")]
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            List<Apartment> apartments = await _apartmentServices.GetTop();
            List<Agent> agents = _agentServices.GetAll();
            List<Review> reviews = await _reviewServices.GetAll();

            HomePageView view = new HomePageView()
            {
                Agents = agents,
                Apartments = apartments,
                Reviews=reviews
            };
            return View(view);
        }
    }
}
