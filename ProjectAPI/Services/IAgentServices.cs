namespace ProjectAPI.Services
{
    public interface IAgentServices
    {
        Task<string> GetAll(bool archive);
        Task<string> GetByAgentId(int id);
    }
}
