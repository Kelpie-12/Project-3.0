using Microsoft.AspNetCore.Mvc;
using Project_3._0.Data.Repositories;
using Project_3._0.Helpers.Html;
using Project_3._0.Model.Domain;
using Project_3._0.Model.View;
using Project_3._0.Services;

namespace Project_3._0.Controllers
{
    [Route("{controller}")]
    public class ObjectsController : Controller
    {
        private readonly IAgentServices _agentServices;
        private readonly IApartmentServices _apartmentServices;
        private readonly IReviewRepository _reviewRepository;
        public ObjectsController(IAgentServices agentServices, IApartmentServices apartmentServices, IReviewRepository reviewRepository)
        {
            _agentServices = agentServices;
            _apartmentServices = apartmentServices;
            _reviewRepository = reviewRepository;
        }
        [HttpGet]
        [ActionName("Objects")]
        [Route("{action}")]
        public IActionResult Index(List<Project_3._0.Model.Domain.Object> objects)
        {
           
            ViewBag.Object = "Объекты";
            foreach (Apartment item in _apartmentServices.GetAll())
            {
                objects.Add(item);
            }
            return View(objects);
        }
        [HttpGet]
        [ActionName("ObjectsSingle")]
        [Route("{action}")]
        public IActionResult ObjectsSingle(int id, ObjectSinglePageView obj)
        {

            //изменить способ получения объекта что бы был id agenta
            obj.Object = _apartmentServices.GetById(id);
            obj.Agent = _agentServices.GetAgentById(obj.Object.AgentId);
            obj.Review = _reviewRepository.GetReviewAgentById(id);

            return View(obj);
        }
    }
}
