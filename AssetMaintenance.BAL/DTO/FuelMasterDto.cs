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
    }
}
