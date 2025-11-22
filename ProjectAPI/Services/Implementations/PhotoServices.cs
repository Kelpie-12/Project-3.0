
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using ProjectAPI.Model;
using ProjectAPI.Model.DTO;

namespace ProjectAPI.Services.Implementations
{
    public class PhotoServices : IPhotoServices
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        public PhotoServices()
        {
            currentDirectory += $"\\wwwroot\\src\\ObjectPhoto\\";
        }
        public Task<string> GetAgentPhotoAsync(AgentDTO agent)
        {

            throw new NotImplementedException();
        }

        public async Task<string> GetAllApartmentPhotoAsync(int id, string route)
        {
            // You can use your own method over here.
            // byte[] b = System.IO.File.ReadAllBytes();   // You can use your own method over here.
            List<string> paths = new List<string>();

            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory + $"{id}\\");
            foreach (var item in directoryInfo.GetFiles())
            {
                paths.Add(route + item.Name /*+ Path.GetFileNameWithoutExtension(item.Name)*/);
            }
            string resalt = JsonSerializer.Serialize(paths, new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            return resalt;
            //нужно отправлять json с массивом ссылок на апи со скачиванием фото
        }

        public async Task<string> GetPhotoAsync(string id)
        {
            try
            {
                string[] s = id.Split('-', StringSplitOptions.RemoveEmptyEntries);
                byte[] b = System.IO.File.ReadAllBytes(currentDirectory + s[0] + "\\" + id);
                string result = JsonSerializer.Serialize(b);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
