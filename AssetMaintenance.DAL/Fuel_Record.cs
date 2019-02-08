//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AssetMaintenance.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fuel_Record
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fuel_Record()
        {
            this.FuelRecord_Detail = new HashSet<FuelRecord_Detail>();
        }
    
        public int Id { get; set; }
        public string FillingStation { get; set; }
        public Nullable<System.DateTime> Period { get; set; }
        public string SupplierCode { get; set; }
        public Nullable<int> ClaimNumber { get; set; }
        public string SupplierName { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public string PaymentCertNo { get; set; }
        public Nullable<double> DiscountAmountPetrol { get; set; }
        public Nullable<double> DiscountAmountDiesel { get; set; }
        public Nullable<double> DiscountAmountGasoline { get; set; }
        public Nullable<double> InvoiceDiscountAmount { get; set; }
        public string RegistrationNo { get; set; }
        public Nullable<double> InvoiceTotalAmount { get; set; }
        public Nullable<double> InvoiceVatAmount { get; set; }
        public Nullable<double> AmountPetrolLt { get; set; }
        public Nullable<double> AmountDieselLt { get; set; }
        public Nullable<double> AmountGasolineLt { get; set; }
        public Nullable<bool> Is_PaymentReceiptGenerate { get; set; }
        public Nullable<bool> Is_Excel { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FuelRecord_Detail> FuelRecord_Detail { get; set; }
    }
}
