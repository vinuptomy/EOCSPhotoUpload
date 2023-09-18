using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IIASA.EOCS.PhotoMicroService.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string DeviceName { get; set; }        
        public int DirectionTypeId { get; set; }
        public int LandCategoryId { get; set; }
        public string Description { get; set; }

    }
}
