using Project_3._0.Data.Repositories;
using Project_3._0.Model.Domain;

namespace Project_3._0.Services.Implementation
{
    public class AgentServices : IAgentServices
    {
        private readonly IAgentsRepository _agentsRepository;
        public AgentServices(IAgentsRepository agentsRepository)
        {
            _agentsRepository = agentsRepository;
        }

        public Agent GetAgentById(int id)
        {
            return _agentsRepository.GetAgentById(id);
        }

        //public async Task<Agent> GetAll()
        //{
        //    return await _agentsRepository.GetAgentByIdAsync("");
        //    //return _agentsRepository.GetAgents();
        //}

        List<Agent> IAgentServices.GetAll()
        {
            return  _agentsRepository.GetAgents();
        }
    }
}
