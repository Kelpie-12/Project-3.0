using ProjectAPI.Model.DTO;

namespace ProjectAPI.Repositories
{
    public interface IAgentRepository
    {
        List<AgentDTO> GetAgents(bool archive);
        AgentDTO GetAgentById( int id );
    }
}
