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
    
    public partial class GFI_AMM_VehicleMaintenance
    {
        public int URI { get; set; }
        public Nullable<int> AssetId { get; set; }
        public Nullable<int> MaintTypeId_cbo { get; set; }
        public string ContactDetails { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyRef { get; set; }
        public string CompanyRef2 { get; set; }
        public string MaintDescription { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> MaintStatusId_cbo { get; set; }
        public Nullable<decimal> EstimatedValue { get; set; }
        public string VATInclInItemsAmt { get; set; }
        public Nullable<decimal> VATAmount { get; set; }
        public Nullable<decimal> TotalCost { get; set; }
        public Nullable<int> CoverTypeId_cbo { get; set; }
        public Nullable<int> CalculatedOdometer { get; set; }
        public Nullable<int> ActualOdometer { get; set; }
        public Nullable<int> CalculatedEngineHrs { get; set; }
        public Nullable<int> ActualEngineHrs { get; set; }
        public string AdditionalInfo { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string AssetStatus { get; set; }
        public string Comment { get; set; }
    }
}