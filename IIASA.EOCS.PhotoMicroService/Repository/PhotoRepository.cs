using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IIASA.EOCS.PhotoMicroService.Models;
using Microsoft.EntityFrameworkCore;
using IIASA.EOCS.PhotoMicroService.DBContexts;

namespace IIASA.EOCS.PhotoMicroService.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly PhotoContext _dbContext;

        public PhotoRepository(PhotoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeletePhoto(int photoId)
        {
            var photo = _dbContext.Photos.Find(photoId);
            _dbContext.Photos.Remove(photo);
            Save();
        }

        public Photo GetPhotoByID(int photoId)
        {
            return _dbContext.Photos.Find(photoId);
        }

        public IEnumerable<Photo> GetPhotos()
        {
            return _dbContext.Photos.ToList();
        }

        public void InsertPhoto(Photo photo)
        {
            _dbContext.Add(photo);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdatePhoto(Photo photo)
        {
            _dbContext.Entry(photo).State = EntityState.Modified;
            Save();
        }

    }
}
