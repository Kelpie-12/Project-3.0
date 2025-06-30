using Microsoft.AspNetCore.Mvc;
using Project_3._0.Model.Domain;
using Project_3._0.Services;

namespace Project_3._0.Controllers
{
    [Route("{controller}")]
    public class AgentsController : Controller
    {
        private readonly IAgentServices _agentServices;
        public AgentsController(IAgentServices agentServices)
        {
            _agentServices = agentServices;
        }
        [HttpGet]
        [ActionName("Agents")]
        [Route("{action}")]
        public IActionResult Index()
        {
            List<Agent> agents = _agentServices.GetAll();
            return View(agents);
        }


    }
}
