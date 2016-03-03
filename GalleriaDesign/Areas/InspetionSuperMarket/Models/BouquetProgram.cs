using GalleriaDesign.Areas.InspetionSuperMarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class BouquetProgram
    {
      
        [Key]
        public int idBouquetProgram { get; set; }
        public string descriptionProgramBP { get; set; }

        public decimal? retailBPR { get; set; }

        public string nameBPR { get; set; }


        public int? totalstemCountBPR { get; set; }

        public int? focalCountBPR { get; set; }

        public string otherFocals { get; set; }
		
        public int colorEnhacedFocal { get; set; }
       
	    public int? basicStemCount { get; set; }

        public string otherBasic { get; set; }

        public string colorenhacedBasic { get; set; }

        public int? fillerStemCount { get; set; }

        public string otherFillerBPR { get; set; }

        public string colorEnhacedFiller { get; set; }

        public int? greensStemCount { get; set; }


        public string otherGreenType { get; set; }

        public string colorEnhacedGreen { get; set; }


        public Boolean pick { get; set; }

        public string supplierBPR { get; set; }


        public string  sleeveBPR { get; set; }

        public Boolean innerWrapBPR { get; set; }

        public int idStoreInformation { get; set; }

        public virtual StoreInformation storeInformation { get; set; }

       public virtual ICollection<ImagesBouquetProgram> imagesBouquetProgam { get; set; }


    }
}