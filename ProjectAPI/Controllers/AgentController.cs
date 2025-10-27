using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Services;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : Controller
    {
        private readonly IAgentServices _agentServices;
        public AgentController(IAgentServices agentServices)
        {
            _agentServices = agentServices;
        }
        [HttpGet]
        [Route("GetAgentById")]
        public async Task<IActionResult> GetAgentById(int id)
        {
            string response = await _agentServices.GetByAgentId(id);
            return Content(response);
        }
        [HttpGet]
        [Route("GetAgents")]
        public async Task<IActionResult> GetAgentsAsync(bool archive = false)
        {
            string response = await _agentServices.GetAll(archive);
            return Content(response);
        }
    }
}
