using Project_3._0.Data.Repositories;
using Project_3._0.Model.Domain;

namespace Project_3._0.Services.Implementation
{
    public class ApartmentServices : IApartmentServices
    {
        private readonly IApartmentRepository _apartmentRepository;
        public ApartmentServices(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }
        public List<Apartment> GetAll()
        {
            return _apartmentRepository.GetAll();
        }

        public Apartment? GetById(int id)
        {
            return _apartmentRepository.GetById(id);
        }
    }
}
