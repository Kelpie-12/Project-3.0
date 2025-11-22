using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Model;
using ProjectAPI.Model.DTO;
using ProjectAPI.Repositories;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {     

        [HttpGet]
        [Route("Ping")]
        public IActionResult Ping(int id)
        {
            return Ok(new { date = DateTime.Now });
        }

    }
}
