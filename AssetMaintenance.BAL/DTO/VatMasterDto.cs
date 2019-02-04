using System;
using System.Collections.Generic;
using System.Text;

namespace AssetMaintenance.BAL.DTO
{
    public class VatMasterDto
    {
        public int VatId { get; set; }
        public double Vat { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
