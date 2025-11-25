using Project_3._0.Model.Domain;

namespace Project_3._0.Services
{
    public interface IPhotoServices
    {
        List<Photo> GetPhotos(string directoryPath);
        Task<byte[]> GetApartmentPhotoByIdAsync(string id);
        Task<IList<string>> GetAllApartmentPhoto(string id);
    }
}
