using Project_3._0.Model.Domain;

namespace Project_3._0.Services.Implementation
{
    public class PhotoServices : IPhotoServices
    {
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
