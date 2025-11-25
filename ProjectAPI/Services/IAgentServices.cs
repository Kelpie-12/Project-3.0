namespace ProjectAPI.Services
{
    public interface IAgentServices
    {
        Task<string> GetAllAsync(bool archive);
        Task<string> GetByAgentIdAsync(int id);
        Task<string> GetAgentPhotoByIdAsync(string id);
        string GetAllAgentPhoto();
    }
}
