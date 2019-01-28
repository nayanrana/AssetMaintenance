
using System;
using System.ComponentModel.DataAnnotations;

namespace AssetMaintenance.BAL.DTO
{
    public class FuelRecordDto
    {
        public int Id { get; set; }
        public string FillingStation { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> PeriodFrom { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> PeriodTo { get; set; }

        public int? ClaimNumber { get; set; }
        public string VoucherNumber { get; set; }
        public string FuelType { get; set; }
        public int? QuantityLitre { get; set; }
        public Nullable<double> DiscountAmount { get; set; }
        public Nullable<double> AmountExclVat { get; set; }
        public Nullable<double> VatAmount { get; set; }
        public Nullable<double> AmountIncVat { get; set; }

        public int Modeofupload { get; set; }
        public FuelRecord_DetailDto fuelRecordManualDto { get; set; }
        public bool? Is_PaymentReceiptGenerate { get; set; }


    }

    public class FuelRecordManualDto
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Period { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public string FillingStation { get; set; }
        public Int64 Id { get; set; }
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
