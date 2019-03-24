using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IIASA.EOCS.PhotoMicroService.Models;

namespace IIASA.EOCS.PhotoMicroService.Repository
{
    public interface IPhotoRepository
    {
        IEnumerable<Photo> GetPhotos();
        Photo GetPhotoByID(int photo);
        void InsertPhoto(Photo photo);
        void DeletePhoto(int PhotoId);
        void UpdatePhoto(Photo photo);
        void Save();
    }
}
