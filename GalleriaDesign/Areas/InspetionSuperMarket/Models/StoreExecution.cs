using GalleriaDesign.Areas.InspetionSuperMarket.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Supermarket.Models
{
    public class StoreExecution
    {
        [Key]
        public int idStoreExecution { get; set; }


        public int idOverallFloral { get; set; }

        public virtual OverallFloralExecution overallFloralExecution { get; set; }


        public int idFlowerPerformance { get; set; }

        public virtual FlowerPerfomance flowerPerfomance { get; set; }



        public int idPullDates { get; set; }

        public virtual PullDates pullDates { get; set; }

        public int idWaterTemperature { get; set; }

        public virtual WaterTemperature waterTemperature { get; set; }

        public int idWaterState { get; set; }

        public virtual WaterState waterState { get; set; }

        public int idCoolerTemperature { get; set; }

        public virtual CoolerTemperature coolerTemperature { get; set; }


        public int idExposureClimate { get; set; }

        public virtual ExposureClimate exposureClimate { get; set; }

        public int exposureDraft { get; set; }

        public  string otherCommentsExecution { get; set; }

        public int idStoreInformation { get; set; }

        public virtual StoreInformation storeInformation { get; set; }

        public virtual ICollection<ImagesStoreExecution> imagesStoreExecution { get; set; }









    }
}