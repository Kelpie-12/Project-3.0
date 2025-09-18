using System.Web.Http;


namespace APIServerP.Controllers
{ 
    public class ValuesController : ApiController
    {
        [AcceptVerbs("GET")]
        [Route("Ping/{id}")]
        public async Task<IHttpActionResult> Ping(int id)
        {
            return Ok(new { date = DateTime.Now, data = id });
        }
    }
}
