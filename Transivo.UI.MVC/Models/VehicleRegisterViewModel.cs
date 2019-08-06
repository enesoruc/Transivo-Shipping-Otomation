using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transivo.UI.MVC.Models
{
    public class VehicleRegisterViewModel
    {
        public string Plate { get; set; }
        public DateTime RegistrationFirstDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegistrationNo { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string CommercialName { get; set; }
        public DateTime ModelYear { get; set; }
        public string CarClass { get; set; }
        public string Genus { get; set; }
        public string Color { get; set; }
        public string MotorNo { get; set; }
        public string ChasisNo { get; set; }
        public string WeightNet { get; set; }
        public string WeightWeigher { get; set; }
        public string SeatsOfNumber { get; set; }
        public string CylinderVolume { get; set; }
        public string FuelType { get; set; }
        public string PurposeOf { get; set; }
        public string MaxLoadWeight { get; set; }
        public string MotorPower { get; set; }
        public string PowerToWeightRatio { get; set; }
        public DateTime NoterySalesDate { get; set; }
        public string NotarySalesNo { get; set; }
        public string NotaryName { get; set; }
        public string DocumentSerialNo { get; set; }

        public int DriverID { get; set; }
    }
}