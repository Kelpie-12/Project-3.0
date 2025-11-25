using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Microsoft.AspNetCore.Routing;
using ProjectAPI.Model.DTO;

namespace ProjectAPI.Services.Implementations
{
    public class PhotoServices : IPhotoServices
    {
        private string currentDirectory = Directory.GetCurrentDirectory();
     
        private JsonSerializerOptions _option;
        public PhotoServices()
        {       
            currentDirectory += $"\\wwwroot\\src";
            _option = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
        }

        public async Task<string> GetAgentPhotoByIdAsync(string id)
        {
            if (id == string.Empty)
            {
                return "Invalid id";
            }
            string path = currentDirectory + $"\\AgentPhoto\\" + id;
            if (!File.Exists(path))
            {
                return "Invalid id";
            }
            byte[] b = await System.IO.File.ReadAllBytesAsync(path);

            string result = JsonSerializer.Serialize(b, _option);
            

            return result;
        }

        public string GetAllAgentPhoto(string route)
        {
            string path = currentDirectory + $"\\AgentPhoto\\";
            List<string> paths = new List<string>();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                return "Invalid id";
            }
            foreach (var item in directoryInfo.GetFiles())
            {
                paths.Add(route + item.Name /*+ Path.GetFileNameWithoutExtension(item.Name)*/);
            }
            string resalt = JsonSerializer.Serialize(paths, _option);
            return resalt;
        }

        public string GetAllApartmentPhoto(int id, string route)
        {
            List<string> paths = new List<string>();
            string path = currentDirectory + $"\\ObjectPhoto\\{id}\\";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                return "Invalid id";
            }
            foreach (var item in directoryInfo.GetFiles())
            {
                paths.Add(route + item.Name /*+ Path.GetFileNameWithoutExtension(item.Name)*/);
            }
            string resalt =  JsonSerializer.Serialize(paths,_option);
            return  resalt;
            //нужно отправлять json с массивом ссылок на апи со скачиванием фото
        }

        public async Task<string> GetApartmentPhotoByIdAsync(string id)
        {
            //string contentType = "image/jpeg";
            if (id == string.Empty)
            {
                return "Invalid id";
            }
            string[] s = id.Split('-', StringSplitOptions.RemoveEmptyEntries);
            string path = currentDirectory + $"\\ObjectPhoto\\" + s[0] + "\\" + id;
            if (!File.Exists(path))
            {
                return "Indvid id";
            }
            byte[] b = await System.IO.File.ReadAllBytesAsync(path);

            string result = JsonSerializer.Serialize(b,_option);

            //System.Drawing.Image ImageFromFile = System.Drawing.Image.FromFile(currentDirectory + s[0] + "\\" + id);
            //Bitmap bmp = new Bitmap(ImageFromFile);//Bitmap конвертирую в массив байтов
            //ImageConverter converter = new ImageConverter();
            //byte[] ImageInArray = (byte[])converter.ConvertTo(bmp, typeof(byte[]));              
            //string result = JsonSerializer.Serialize(ImageInArray);

            //   Results.File(b, contentType, id);

            return result;
        }
    }
}
