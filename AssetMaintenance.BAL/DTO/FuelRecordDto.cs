﻿
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

        public FuelRecordManualDto fuelRecordManualDto { get; set; }

    }

    public class FuelRecordManualDto
    {
        public Nullable<System.DateTime> Period { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string FillingStation { get; set; }
        public int ClaimNumber { get; set; }
        public Guid VoucherNumber { get; set; }
        public string FuelType { get; set; }
        public int QuantityLiter { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<decimal> VatAmount { get; set; }
        public Nullable<decimal> AmountInc { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
    }

    
}
