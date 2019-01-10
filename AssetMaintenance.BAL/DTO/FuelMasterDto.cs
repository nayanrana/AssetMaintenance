using System;
using System.Collections.Generic;
using System.Text;

namespace AssetMaintenance.BAL.DTO
{
    public class FuelMasterDto
    {
        public long FuelId { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public long CreatedBy { get; set; }
        public string Type { get; set; }
        public DateTime PriceDate { get; set; }
    }

    public class FuelMasterViewModelDto
    {
        public List<FuelMasterDto> FuelList { get; set; }

        public List<FuelMasterDto> DieselList { get; set; }

        public List<FuelMasterDto> GasoloneList { get; set; }

    }
}
