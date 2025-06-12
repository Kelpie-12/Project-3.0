using Project_3._0.Model.Domain;

namespace Project_3._0.Services.Implementation
{
    public interface IApartmentServices
    {
        List<Apartment> GetAll();
        Apartment? GetById(int id);
    }
}
