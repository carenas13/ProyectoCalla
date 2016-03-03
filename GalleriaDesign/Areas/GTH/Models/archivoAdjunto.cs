using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Areas.GTH.Models
{
    public class ArchivoAdjunto
    {
        [Key]
        public int idArchivoAdjunto { get; set; }
        public string comentario { get; set; }
        [Column(TypeName = "image")]
        public byte[] image { get; set; }

        public int idFormacionYDesarrollo { get; set; }

        public virtual FormacionYDesarrollo formacionYDesarrollo { get; set; }

    }
}