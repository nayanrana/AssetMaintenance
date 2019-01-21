
using System;

namespace AssetMaintenance.BAL.DTO
{
    public class FuelRecordDto
    {
        public int Id { get; set; }
        public string FillingStation { get; set; }
        public Nullable<System.DateTime> PeriodFrom { get; set; }
        public Nullable<System.DateTime> PeriodTo { get; set; }

        public string RegistrationNo { get; set; }
        public Nullable<decimal> FuelInvoice { get; set; }
        public int BatchNo { get; set; }
        public decimal RetailPrice { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public int Modeofupload { get; set; }
        public FuelRecordManualDto fuelRecordManualDto { get; set; }

    }

    public class FuelRecordManualDto
    {
        public DateTime Period { get; set; }
        public DateTime Date { get; set; }
        public string FillingStation { get; set; }
        public int ClaimNumber { get; set; }
        public string VoucherNumber { get; set; }
        public string FuelType { get; set; }
        public int QuantityLitre { get; set; }
        public Nullable<double> Amount { get; set; }
        public Nullable<double> DiscountAmount { get; set; }
        public Nullable<double> VatAmount { get; set; }
        public Nullable<double> AmountInc { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
    }

    
}
