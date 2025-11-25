using System.Net.Http;
using System;
using Project_3._0.Data.Repositories;
using Project_3._0.Data.Repositories.Implementations;
using Project_3._0.Model.Domain;

namespace Project_3._0.Services.Implementation
{
    public class AgentServices : IAgentServices
    {
        private readonly IAgentsRepository _agentsRepository;
        private readonly IHttpClientFactory _clientFactory;
        public AgentServices(IAgentsRepository agentsRepository, IHttpClientFactory clientFactory)
        {
            _agentsRepository = agentsRepository;
            _clientFactory = clientFactory;
        }

        public async Task<Agent?> GetAgentByIdAsync(int id)
        {
            HttpClient client = _clientFactory.CreateClient("Agent");
            Agent? agent = await client.GetFromJsonAsync<Agent>($"GetAgentById?id={id}");


            using var response = await client.GetAsync($"GetAgentPhotoById?id={agent.Id}");
            string a = await response.Content.ReadAsStringAsync(); //== "Invalid id";


            if (a == "Invalid id")
            {
                return agent;
            }
            byte[]? img = response.Content.ReadFromJsonAsync<byte[]>().Result;
            agent.Image = img;

            //Console.WriteLine($"Agent: id={agent.Id}, {agent.FirstName}");
            return agent;

        }


        public async Task<List<Agent>> GetAllAgentAsync(bool inStorage)
        {
            HttpClient client = _clientFactory.CreateClient("Agent");
            List<Agent?> agent = await client.GetFromJsonAsync<List<Agent>>($"GetAgents?archive={inStorage}");          

            // Console.WriteLine($"Agent: id={agent.Id}, {agent.FirstName}");
            return agent;
        }


    }
}
