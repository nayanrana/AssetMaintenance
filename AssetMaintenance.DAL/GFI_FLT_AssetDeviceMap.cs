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
    
    public partial class GFI_FLT_AssetDeviceMap
    {
        public int MapID { get; set; }
        public Nullable<int> AssetID { get; set; }
        public string DeviceID { get; set; }
        public string SerialNumber { get; set; }
        public string Status_b { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public int MaxNoLogDays { get; set; }
    }
}
