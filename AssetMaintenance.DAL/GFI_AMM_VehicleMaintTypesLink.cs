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
    
    public partial class GFI_AMM_VehicleMaintTypesLink
    {
        public int URI { get; set; }
        public Nullable<int> MaintURI { get; set; }
        public Nullable<int> AssetId { get; set; }
        public Nullable<int> MaintTypeId { get; set; }
        public Nullable<System.DateTime> NextMaintDate { get; set; }
        public Nullable<System.DateTime> NextMaintDateTG { get; set; }
        public Nullable<int> CurrentOdometer { get; set; }
        public Nullable<int> NextMaintOdometer { get; set; }
        public Nullable<int> NextMaintOdometerTG { get; set; }
        public Nullable<int> CurrentEngHrs { get; set; }
        public Nullable<int> NextMaintEngHrs { get; set; }
        public Nullable<int> NextMaintEngHrsTG { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
