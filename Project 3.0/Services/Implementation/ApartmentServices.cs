using Project_3._0.Data.Repositories;
using Project_3._0.Model.Domain;

namespace Project_3._0.Services.Implementation
{
    public class ApartmentServices : IApartmentServices
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IPhotoServices _photoServices;
        public ApartmentServices(IApartmentRepository apartmentRepository, IHttpClientFactory clientFactory, IPhotoServices photoServices)
        {
            _apartmentRepository = apartmentRepository;
            _clientFactory = clientFactory;
            _photoServices = photoServices;
        }
        public async Task<List<Apartment>> GetAll(bool brandNew)
        {
            HttpClient client = _clientFactory.CreateClient("Apartment");
            List<Apartment> apartment = await client.GetFromJsonAsync<List<Apartment>>($"GetAll?brandNew={brandNew}");
            foreach (Apartment item in apartment)
            {
                item.Photo = _photoServices.GetPhotos(item.PathPhoto);
            }
            Console.WriteLine($"Apartment: id={apartment[0].Id}, {apartment[0].Street}");
            return apartment;
        }
        //public List<Apartment> GetAll(bool brandNew)
        //{
        //    return _apartmentRepository.GetAll(brandNew);
        //}

        public async Task<Apartment?> GetById(int id)
        {
            HttpClient client = _clientFactory.CreateClient("Apartment");
            Apartment apartment = await client.GetFromJsonAsync<Apartment>($"GetById?id={id}");

            apartment.Photo = _photoServices.GetPhotos(apartment.PathPhoto);
            Console.WriteLine($"Apartment: id={apartment.Id}, {apartment.Street}");
            return apartment;
        }

        public async Task<List<Apartment>> GetTop()
        {
            HttpClient client = _clientFactory.CreateClient("Apartment");
            List<Apartment> apartment = await client.GetFromJsonAsync<List<Apartment>>($"GetTop");
            foreach (Apartment item in apartment)
            {
                item.Photo = _photoServices.GetPhotos(item.PathPhoto);
            }
            Console.WriteLine($"Apartment: id={apartment[0].Id}, {apartment[0].Street}");
            return apartment;
        }
    }
}
