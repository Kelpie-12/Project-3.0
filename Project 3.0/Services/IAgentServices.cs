using Project_3._0.Model.Domain;

namespace Project_3._0.Services
{
    public interface IAgentServices
    {
        Task<Agent?> GetAllAgent(bool inStorage);
        List<Agent> GetAll();
        Agent GetAgentById(int id);
        Task<Agent?> GetAgentByIdAsync(int id);
    }
}
