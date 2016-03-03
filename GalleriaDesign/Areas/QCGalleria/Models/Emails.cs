using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GalleriaDesign.Models
{
    public class Emails
    {
        [Key]
        public int emailID{get;set;}
        public string userName { get; set; }
        public Boolean userIsActive { get; set;}
        public string addressEmail { get; set;}
        public int emailBodyID { get; set; }
        public virtual EmailsBody emailsBody { get; set; }
    }
}