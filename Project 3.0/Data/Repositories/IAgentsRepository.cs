using Project_3._0.Model.Domain;

namespace Project_3._0.Data.Repositories
{
    public interface IAgentsRepository
    {
        List<Agent> GetAgents();
        Agent GetAgentById(int id);
    }
}
