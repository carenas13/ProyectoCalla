using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Areas.GTH.Models
{
    public class Participante
    {
        [Key]
        public int idPartipante { get; set; }
        public string nombreParticipante { get; set; }
        public string nmIdentificacion { get; set; }
        public string areaDeTrabajo { get; set; }
        public string cargo { get; set; }

        public int idFormacionYDesarrollo { get; set; }

        public virtual FormacionYDesarrollo formacionYDesarrollo { get; set; }
    }
}