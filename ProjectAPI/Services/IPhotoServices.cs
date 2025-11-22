using ProjectAPI.Model.DTO;

namespace ProjectAPI.Services
{
    public interface IPhotoServices
    {
        Task<string> GetAgentPhotoAsync(AgentDTO agent);
        Task<string> GetAllApartmentPhotoAsync(int id, string route);
        Task<string> GetPhotoAsync(string id);
    }
}
