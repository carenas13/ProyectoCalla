using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Areas.GTH.Models
{
    public class FormacionYDesarrollo
    {
        [Key]
        public int idFormacionYDesarrollo { get; set; }
        public string nombreTema { get; set;}
        public DateTime fecha { get; set; }
        public int duracion { get; set; }
        public Boolean capacitacionProgramada { get; set; }
        public string objetivoCapactiacion { get; set; }
        public string contenido { get; set; }

        public ICollection<ArchivoAdjunto> archivoAdjunto { get; set; }
        public ICollection<Participante> participante { get; set; }
    }
}