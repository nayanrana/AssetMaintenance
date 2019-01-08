
using System;

namespace AssetMaintenance.BAL.DTO
{
    public class FuelRecordDto
    {
        public int Id { get; set; }
        public string FillingStation { get; set; }
        public Nullable<System.DateTime> Period { get; set; }
        public string RegistrationNo { get; set; }
        public Nullable<decimal> FuelInvoice { get; set; }
        public int BatchNo { get; set; }
        public decimal RetailPrice { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
    }
}
