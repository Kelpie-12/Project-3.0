using Project_3._0.Model.Domain;

namespace Project_3._0.Data.Repositories
{
    public interface IApartmentRepository
    {
        List<Apartment> GetAll(bool brandNew);
        Apartment? GetById(int id);
        List<Apartment> GetTop();
    }
}
