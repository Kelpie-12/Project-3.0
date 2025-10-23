using Project_3._0.Model.Domain;

namespace Project_3._0.Services
{
    public interface IApartmentServices
    {
        Task<List<Apartment>> GetAll(bool brandNew);
        Apartment? GetById(int id);
        List<Apartment> GetTop();
    }
}
