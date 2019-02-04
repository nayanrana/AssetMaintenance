using System;
using System.Collections.Generic;
using System.Text;

namespace AssetMaintenance.BAL.DTO
{
    public class AssetMaintenanceDetailDto
    {
        public int URI { get; set; }
        public string Asset { get; set; }
        public string AssetNo { get; set; }
        public string Maintenance { get; set; }
        public DateTime? Reminder { get; set; }
        public DateTime? NextMaintenance { get; set; }
        public string Category { get; set; }
        public int? ActualOdometer { get; set; }
        public int? ActualEngineHrs { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Amount { get; set; }

        ///   Maintenance Fields ////
        public string ContactDetails { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyRef { get; set; }
        public string CompanyRef2 { get; set; }
        public string MaintDescription { get; set; }
        public Nullable<int> MaintStatusId_cbo { get; set; }
        public Nullable<decimal> EstimatedValue { get; set; }
        public string VATInclInItemsAmt { get; set; }
        public Nullable<decimal> VATAmount { get; set; }
        public Nullable<decimal> TotalCost { get; set; }
        public Nullable<int> CoverTypeId_cbo { get; set; }
        public Nullable<int> CalculatedOdometer { get; set; }
        public Nullable<int> CalculatedEngineHrs { get; set; }
        public string AdditionalInfo { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string AssetStatus { get; set; }
        public string Comment { get; set; }
        public Nullable<int> AssetId { get; set; }
        public Nullable<int> MaintTypeId_cbo { get; set; }
        public List<lstPartDetails> lstParts { get; set; }
        public string Parts { get; set; }
        public string FileName { get; set; }

    }

    public class lstPartDetails
    {
        public int URI { get; set; }

        public int MaintURI { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> UnitCost { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
