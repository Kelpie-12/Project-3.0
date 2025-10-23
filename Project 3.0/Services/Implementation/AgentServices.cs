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
            Agent agent = await client.GetFromJsonAsync<Agent>($"GetAgentById?id={id}");

            Console.WriteLine($"Agent: id={agent.Id}, {agent.FirstName}");
            return agent;

        }

        public Agent GetAgentById(int id)
        {
            return _agentsRepository.GetAgentById(id);
        }

        List<Agent> IAgentServices.GetAll()
        {
            return _agentsRepository.GetAgents();
        }
    }
}
