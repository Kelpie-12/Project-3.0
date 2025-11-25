using Project_3._0.Model.Domain;

namespace Project_3._0.Services
{
    public interface IAgentServices
    {
        Task<List<Agent?>> GetAllAgentAsync(bool inStorage);
        
        Task<Agent> GetAgentByIdAsync(int id);
    }
}
