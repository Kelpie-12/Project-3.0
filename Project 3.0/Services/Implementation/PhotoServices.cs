using System.Net.Http;
using System;
using System.Threading.Tasks;
using Project_3._0.Model.Domain;

namespace Project_3._0.Services.Implementation
{
    public class PhotoServices : IPhotoServices
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;
        public PhotoServices(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
        }
        public async Task<IList<string>> GetAllApartmentPhoto(string id)
        {
            IList<string>? res = new List<string>();
            HttpClient client = _clientFactory.CreateClient("Apartment");
            IList<string>? route = await client.GetFromJsonAsync<List<string>>($"GetAllApartmentPhoto?id={id}");//придумать как передать пути
            res = route;
            //"/api/Agent/GetAgentPhotoById?id=",


            return res;
        }

        public async Task<byte[]> GetApartmentPhotoByIdAsync(string id)
        {           
            HttpClient client = _clientFactory.CreateClient("Server");
           // var r = id.Substring(1);
            //byte[]? res = await client.GetFromJsonAsync<byte[]>(id);

            using var response = await client.GetAsync(id);
            var res = response.Content.ReadFromJsonAsync<byte[]>().Result;
            return res;
        }

        public List<Photo> GetPhotos(string directoryPath)
        {
            List<Photo> tmp = new List<Photo>();
            var dir = Directory.GetCurrentDirectory();
            dir += "\\wwwroot" + directoryPath;
            //dir = dir.Substring(0, dir.Length - 10);
            DirectoryInfo directoryInfo = new DirectoryInfo(dir);
            foreach (var file in directoryInfo.GetFiles()) //проходим по файлам
            {
                // if (Path.GetExtension(file.FullName) == "jpg" || Path.GetExtension(file.FullName) == "png"|| Path.GetExtension(file.FullName) == "jpeg")
                // {                  
                tmp.Add(new Photo() { Id = 0, ObjectId = 0, Path = directoryPath + "\\" + file.Name });
                // }
            }

            return tmp;
        }
    }
}
