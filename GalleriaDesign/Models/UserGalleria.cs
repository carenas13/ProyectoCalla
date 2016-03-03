using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Models
{
    public class UserGalleria
    {
        public string IDUser { get; set; }
        public string userName{ get; set; }
        public string fullName { get; set; }
        public string rol { get; set; }
        public List<RolGalleria> roles { get; set; }
        
    }
}