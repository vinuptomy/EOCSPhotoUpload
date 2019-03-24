using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using Microsoft.AspNetCore.Hosting;
using IIASA.EOCS.PhotoMicroService.Models;
using IIASA.EOCS.PhotoMicroService.Repository;

namespace IIASA.EOCS.PhotoMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IHostingEnvironment _env;
    
        // GET: api/Photo
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}


        private readonly IPhotoRepository _photoRepository;

        public PhotoController(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }


        // GET: api/Photo
        [HttpGet]
        public IActionResult Get()
        {
            var photos = _photoRepository.GetPhotos();
            return new OkObjectResult(photos);
        }

        // GET: api/Photo/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var photo = _photoRepository.GetPhotoByID(id);
            return new OkObjectResult(photo);
        }

        //// POST: api/Photo
        //[HttpPost]
        //public IActionResult Post([FromBody] Photo photo)
        //{
        //    using (var scope = new TransactionScope())
        //    {
        //        _photoRepository.InsertPhoto(photo);
        //        scope.Complete();
        //        return CreatedAtAction(nameof(Get), new { id = photo.Id }, photo);
        //    }
        //}



        // POST: api/Photo
        [HttpPost]
        [Consumes("multipart/form-data")]
        //[Route("api/TestUpload")]
        public async Task<IActionResult> UploadAsync([ModelBinder(BinderType = typeof(JsonModelBinder))] Photo photo,
        IFormFile formFile)
        {

            var uploads = Path.Combine(_env.WebRootPath, "uploads");

            if (formFile.Length > 0)
            {
                var filePath = Path.Combine(uploads, formFile.FileName);
                using (var fileStream = new FileStream(Path.Combine(uploads, formFile.FileName), FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                    fileStream.Flush();
                }
            }

            using (var scope = new TransactionScope())
            {
                _photoRepository.InsertPhoto(photo);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = photo.Id }, photo);
            }
        }


        // PUT: api/Photo/5
        [HttpPut]
        public IActionResult Put([FromBody] Photo photo)
        {
            if (photo != null)
            {
                using (var scope = new TransactionScope())
                {
                    _photoRepository.UpdatePhoto(photo);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _photoRepository.DeletePhoto(id);
            return new OkResult();
        }
    }
}
