using ProjectAPI.Model.DTO;

namespace ProjectAPI.Repositories
{
    public interface IAgentRepository
    {
        Task<List<AgentDTO>> GetAgents(bool archive);
        Task<AgentDTO> GetAgentById(int id);
    }
}
