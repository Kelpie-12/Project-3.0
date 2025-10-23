using Project_3._0.Model.Domain;

namespace Project_3._0.Services
{
    public interface IAgentServices
    {
        List<Agent> GetAll();
        Agent GetAgentById(int id);
        Task<Agent?> GetAgentByIdAsync(int id);
    }
}
