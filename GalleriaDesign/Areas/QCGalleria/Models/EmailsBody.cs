using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Models
{
    public class EmailsBody
    {   [Key]
        public int emailBodyID { get; set; }
        public string emailFrom { get; set; }
        public string passwordEmailFrom { get; set; }
        public string subject { get; set; } 
        public string emailContent { get; set; }
        public string signatureEmail { get; set; }
        public ICollection<Emails> emails { get; set; }
        public ICollection<QualityReport> qualityReport { get; set; }
    }
}