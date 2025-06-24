using Microsoft.AspNetCore.Mvc;
using Project_3._0.Data.Repositories;
using Project_3._0.Model.Domain;
using Project_3._0.Model.View;
using Project_3._0.Services;

namespace Project_3._0.Controllers
{
    [Route("{controller}")]
    public class HomeController : Controller
    {
        private readonly IApartmentServices _apartmentServices;
        private readonly IAgentsRepository _agentsRepository;
        private readonly IReviewRepository _reviewRepository;
        public HomeController(IApartmentServices apartmentServices, IAgentsRepository agentsRepository, IReviewRepository reviewRepository)
        {
            _apartmentServices = apartmentServices;
            _agentsRepository = agentsRepository;
            _reviewRepository = reviewRepository;
        }
        [HttpGet]
        [ActionName("Home")]
        [Route("/")]
        public IActionResult Index()
        {
            List<Apartment> apartments = _apartmentServices.GetTop();
            List<Agent> agents = _agentsRepository.GetAgents();
            List<Review> reviews = _reviewRepository.GetAll();

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
