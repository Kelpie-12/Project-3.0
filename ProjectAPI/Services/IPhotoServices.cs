using ProjectAPI.Model.DTO;

namespace ProjectAPI.Services
{
    public interface IPhotoServices
    {
        string GetAllAgentPhoto(string route);
        string GetAllApartmentPhoto(int id, string route);
        Task<string> GetApartmentPhotoByIdAsync(string id);
        Task<string> GetAgentPhotoByIdAsync(string id);
        Task<byte[]> GetAgentPhotoByIdByteAsync(string id);
    }
}
