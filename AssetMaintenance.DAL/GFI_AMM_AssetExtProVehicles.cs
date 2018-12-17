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
    
    public partial class GFI_AMM_AssetExtProVehicles
    {
        public int AssetId { get; set; }
        public string VIN { get; set; }
        public string Description { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public Nullable<int> VehicleTypeId_cbo { get; set; }
        public string Manufacturer { get; set; }
        public Nullable<int> YearManufactured { get; set; }
        public Nullable<System.DateTime> PurchasedDate { get; set; }
        public Nullable<decimal> PurchasedValue { get; set; }
        public string PORef { get; set; }
        public Nullable<int> ExpectedLifetime { get; set; }
        public Nullable<decimal> ResidualValue { get; set; }
        public string EngineSerialNumber { get; set; }
        public string EngineType { get; set; }
        public Nullable<int> EngineCapacity { get; set; }
        public Nullable<int> EnginePower { get; set; }
        public string FuelType { get; set; }
        public Nullable<decimal> StdConsumption { get; set; }
        public string ExternalReference { get; set; }
        public string InService_b { get; set; }
        public string AdditionalInfo { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public string Field1Value { get; set; }
        public string Field2Value { get; set; }
        public string Field3Value { get; set; }
        public string Field4Value { get; set; }
        public string Field5Value { get; set; }
        public string Field6Value { get; set; }
        public Nullable<int> Field1Id { get; set; }
        public Nullable<int> Field2Id { get; set; }
        public Nullable<int> Field3Id { get; set; }
        public Nullable<int> Field4Id { get; set; }
        public Nullable<int> Field5Id { get; set; }
        public Nullable<int> Field6Id { get; set; }
    
        public virtual GFI_FLT_AssetDataType GFI_FLT_AssetDataType { get; set; }
        public virtual GFI_FLT_AssetDataType GFI_FLT_AssetDataType1 { get; set; }
        public virtual GFI_FLT_AssetDataType GFI_FLT_AssetDataType2 { get; set; }
        public virtual GFI_FLT_AssetDataType GFI_FLT_AssetDataType3 { get; set; }
        public virtual GFI_FLT_AssetDataType GFI_FLT_AssetDataType4 { get; set; }
        public virtual GFI_FLT_Asset GFI_FLT_Asset { get; set; }
        public virtual GFI_FLT_AssetDataType GFI_FLT_AssetDataType5 { get; set; }
    }
}
