using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Model.DTO;
using ProjectAPI.Model;
using ProjectAPI.Repositories;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentRepository _apartmentRepository;
        public ApartmentController(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(FileUploadRequest request)
        {
            //long size = files.Sum(f => f.Length);
            long size = request.File.Sum(f => f.Length);

            FileUploadRequestDTO tmp = new FileUploadRequestDTO(request);
            int id = _apartmentRepository.SetNewApartment(tmp);
            int i = 1;
            // full path to file in temp location
            //  var filePath = Path.GetTempFileName();
            var dir = Directory.GetCurrentDirectory();
            dir = dir.Substring(0, dir.Length - 10);
            dir += $"Project 3.0\\wwwroot\\src\\Photo\\";
            var saveDir = Path.Combine(/*AppDomain.CurrentDomain.BaseDirectory*/dir,/*"~\\Project 3.0\\wwwroot\\Photo",*/ $"{id}");
            if (!Directory.Exists(saveDir))
            {
                Directory.CreateDirectory(saveDir);
            }


            //foreach (var formFile in files)
            //{
            //if (formFile.Length > 0)
            //{
            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await formFile.CopyToAsync(stream);
            //    }
            //}
            //}
            foreach (var item in request.File)
            {
                if (item.Length > 0)
                {
                    var filePath = Path.Combine(saveDir, $"{id}-{i}.png");
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }
                    i++;
                }
            }


            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = request.File.Count, size });
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<ApartmentDTO>> GetAll(bool brandNew)
        {
            List<ApartmentDTO> apartments = new List<ApartmentDTO>();
            apartments = await _apartmentRepository.GetAll(brandNew);

            return apartments;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ApartmentDTO> GetById(int id)
        {
            ApartmentDTO apartments = new ApartmentDTO();
            apartments = await _apartmentRepository.GetById(id);
            return apartments;
        }

        [HttpGet]
        [Route("GetTop")]
        public async Task<List<ApartmentDTO>> GetTop()
        {
            List<ApartmentDTO> apartments = new List<ApartmentDTO>();
            apartments = await _apartmentRepository.GetTop();
            return apartments;
        }


    }
}
