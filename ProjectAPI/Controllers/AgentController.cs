using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjectAPI.Services;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : Controller
    {
        private readonly IAgentServices _agentServices;
        private readonly IPhotoServices _photoServices;
        private readonly IConfiguration _configuration;
        public AgentController(IConfiguration configuration, IAgentServices agentServices, IPhotoServices photoServices)
        {
            _agentServices = agentServices;
            _photoServices = photoServices;
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAgentById")]
        public async Task<IActionResult> GetAgentById(int id)
        {
            string response = await _agentServices.GetByAgentIdAsync(id);
            return Content(response);
        }
        [HttpGet]
        [Route("GetAgents")]
        public async Task<IActionResult> GetAgentsAsync(bool archive = false)
        {
            string response = await _agentServices.GetAllAsync(archive);
            return Content(response);
        }
        [HttpGet]
        [Route("GetAllAgentPhoto")]
        public IActionResult GetAllAgentPhotoAsync()
        {
            string response = _photoServices.GetAllAgentPhoto(_configuration.GetRequiredSection("PhotoRoute")
                                                                            .GetSection("Agent").Value ?? "Invalid route");
            return Content(response);

        }

        [HttpGet]
        [Route("GetAgentPhotoById")]
        public async Task<IActionResult> GetAgentPhotoByIdAsync(string id)
        {
            string response = await _photoServices.GetAgentPhotoByIdAsync(id);
            //if (response == "Invalid id")
            //{
            //    return Content(StatusCodes.Status400BadRequest.ToString());
            //}
            return Content(response);
        }
    }
}
