using ProjectAPI.Model;
using ProjectAPI.Model.DTO;
using ProjectAPI.Repositories.Implementations;

namespace ProjectAPI.Repositories
{
    public interface IApartmentRepository
    {
        int SetNewApartment(FileUploadRequestDTO aprt);
        Task<List<ApartmentDTO>> GetAll(bool brandNew);
        Task<ApartmentDTO?> GetById(int id);
        Task<List<ApartmentDTO>> GetTop();

    }
}
