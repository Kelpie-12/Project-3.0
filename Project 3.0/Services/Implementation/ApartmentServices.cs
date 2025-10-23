using Project_3._0.Data.Repositories;
using Project_3._0.Model.Domain;

namespace Project_3._0.Services.Implementation
{
    public class ApartmentServices : IApartmentServices
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IHttpClientFactory _clientFactory;
        public ApartmentServices(IApartmentRepository apartmentRepository, IHttpClientFactory clientFactory)
        {
            _apartmentRepository = apartmentRepository;
            _clientFactory = clientFactory;
        }
        public async Task<List<Apartment>> GetAll(bool brandNew)
        {
            HttpClient client = _clientFactory.CreateClient("Apartment");
            List<Apartment> apartment = await client.GetFromJsonAsync<List<Apartment>>($"GetAll?brandNew={brandNew}");

            Console.WriteLine($"Apartment: id={apartment[0].Id}, {apartment[0].Street}");
            return apartment;           
        }
        //public List<Apartment> GetAll(bool brandNew)
        //{
        //    return _apartmentRepository.GetAll(brandNew);
        //}

        public Apartment? GetById(int id)
        {
            return _apartmentRepository.GetById(id);
        }

        public List<Apartment> GetTop()
        {
            return _apartmentRepository.GetTop();
        }
    }
}
