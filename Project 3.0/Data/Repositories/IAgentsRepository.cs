using Project_3._0.Data.Repositories.Implementations;
using Project_3._0.Model.Domain;

namespace Project_3._0.Data.Repositories
{
    public interface IAgentsRepository
    {
        static HttpClient client = new HttpClient();
        List<Agent> GetAgents();
        Agent GetAgentById(int id);
      //async  Task<Agent> GetAgentByIdAsync(string path)
      //  {
      //      client.BaseAddress = new Uri("http://localhost:5190/api/GetAgents");
      //      client.DefaultRequestHeaders.Accept.Clear();
      //      client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

      //      Agent agent = new Agent();
      //      HttpResponseMessage response = await client.GetAsync(path);
      //      if (response.IsSuccessStatusCode)
      //      {
      //          agent = await response.Content.ReadFromJsonAsync<Agent>();

      //      }
      //      return agent;
      //  }
    }
}
