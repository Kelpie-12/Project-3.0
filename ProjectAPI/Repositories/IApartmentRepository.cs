using ProjectAPI.Model;
using ProjectAPI.Model.DTO;
using ProjectAPI.Repositories.Implementations;

namespace ProjectAPI.Repositories
{
    public interface IApartmentRepository
    {
        int SetNewApartment(FileUploadRequestDTO aprt);
    }
}
