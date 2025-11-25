using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Microsoft.VisualBasic;
using ProjectAPI.Model.DTO;
using ProjectAPI.Repositories;

namespace ProjectAPI.Services.Implementations
{
    public class ApartmentServices : IApartmentServices
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly JsonSerializerOptions options;
        public ApartmentServices(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
            options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
        }
        public async Task<string> GetAll(bool @new)
        {
            List<ApartmentDTO>? apartments = await _apartmentRepository.GetAll(@new);
            string json = JsonSerializer.Serialize(apartments, options);
            return json;
        }

        public async Task<string> GetById(int id)
        {
            ApartmentDTO? apartment = await _apartmentRepository.GetById(id);
            string res= JsonSerializer.Serialize(apartment, options);
            return res;
        }

        public async Task<string> GetTop()
        {
            List<ApartmentDTO> apartments = await _apartmentRepository.GetTop();
            string json = JsonSerializer.Serialize(apartments, options);
            return json;
        }
    }
}
