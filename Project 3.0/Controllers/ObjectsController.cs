using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_3._0.Data.Repositories;
using Project_3._0.Helpers.Html;
using Project_3._0.Model.Domain;
using Project_3._0.Model.View;
using Project_3._0.Services;
using Project_3._0.Services.Implementation;

namespace Project_3._0.Controllers
{
    [Route("{controller}")]
    public class ObjectsController : Controller
    {
        private readonly IAgentServices _agentServices;
        private readonly IApartmentServices _apartmentServices;
        private readonly IReviewServices _reviewServices;
        public ObjectsController(IAgentServices agentServices, IApartmentServices apartmentServices, IReviewServices reviewServices)
        {
            _agentServices = agentServices;
            _apartmentServices = apartmentServices;
            _reviewServices = reviewServices;
        }
        [HttpGet]
        [ActionName("Objects")]
        [Route("{action}")]
        public async Task<IActionResult> Index(int objectType, List<Project_3._0.Model.Domain.Object> objects)
        {
            //реализовать еnum
            if (objectType == 0 )
            {
                foreach (Apartment item in await _apartmentServices.GetAll(true))
                {
                    objects.Add(item);
                }
                ViewBag.Object = "Новостройки";
                ViewBag.Desc = "Мы предлагаем современные жилые комплексы, которые строятся с учетом последних технологий и стандартов комфорта. Они отличаются современным дизайном, улучшенной инфраструктурой и высоким уровнем энергоэффективности. Покупка квартиры в новостройке становится все более популярной благодаря возможностям индивидуальной планировки, современным материалам и развитой социальной инфраструктуре рядом с домом. В таких жилых комплексах часто реализуются дополнительные удобства: паркинги, детские площадки, спортивные зоны и коммерческие помещения. Инвестирование в новостройки также считается выгодным вложением, поскольку такие объекты обычно растут в цене и предоставляют возможность выбрать жилье по своему вкусу и бюджету.";

            }
            else if (objectType == 1)
            {
                foreach (Apartment item in await _apartmentServices.GetAll(false))
                {
                    objects.Add(item);
                }
                ViewBag.Object = "Вторичное жилье";
                ViewBag.Desc = "Мы предлагаем объекты в различных районах города, с разной площадью и планировками, чтобы каждый нашел жилье по своему вкусу и бюджету. ";
            }

            return View(objects);
        }
        [HttpGet]
        [ActionName("ObjectsSingle")]
        [Route("{action}")]
        public async Task<IActionResult> ObjectsSingle(int id, ObjectSinglePageView obj)
        {
            //изменить способ получения объекта что бы был id agenta
            obj.Object = await _apartmentServices.GetById(id);            
            obj.Agent = await _agentServices.GetAgentByIdAsync(obj.Object.Id);//_agentServices.GetAgentById(obj.Object.AgentId);
            obj.Review = await _reviewServices.GetReviewsByAgentId(id);

            return View(obj);
        }
    }
}
