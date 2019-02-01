
using System;
using System.ComponentModel.DataAnnotations;

namespace AssetMaintenance.BAL.DTO
{
    public class FuelRecordDto
    {
        public int Id { get; set; }
        public string FillingStation { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> Period { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> InvoiceDate { get; set; }

        public string SupplierCode { get; set; }
        public Nullable<int> ClaimNumber { get; set; }
        public string SupplierName { get; set; }
        public string InvoiceNo { get; set; }
        public string PaymentCertNo { get; set; }
        public Nullable<double> DiscountAmountDiesel { get; set; }
        public Nullable<double> DiscountAmountGasoline { get; set; }
        public Nullable<double> InvoiceDiscountAmount { get; set; }
        public string RegistrationNo { get; set; }
        public Nullable<double> InvoiceTotalAmount { get; set; }
        public Nullable<double> InvoiceVatAmount { get; set; }
        public Nullable<double> AmountDieselLt { get; set; }
        public Nullable<double> AmountGasolineLt { get; set; }

        public int Modeofupload { get; set; }
        public FuelRecord_DetailDto fuelRecordManualDto { get; set; }
        public bool? Is_PaymentReceiptGenerate { get; set; }
        public bool? Is_Excel { get; set; }

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
