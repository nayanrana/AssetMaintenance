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
    
    public partial class GFI_FLT_AssetDataType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GFI_FLT_AssetDataType()
        {
            this.GFI_AMM_AssetExtProVehicles = new HashSet<GFI_AMM_AssetExtProVehicles>();
            this.GFI_AMM_AssetExtProVehicles1 = new HashSet<GFI_AMM_AssetExtProVehicles>();
            this.GFI_AMM_AssetExtProVehicles2 = new HashSet<GFI_AMM_AssetExtProVehicles>();
            this.GFI_AMM_AssetExtProVehicles3 = new HashSet<GFI_AMM_AssetExtProVehicles>();
            this.GFI_AMM_AssetExtProVehicles4 = new HashSet<GFI_AMM_AssetExtProVehicles>();
            this.GFI_AMM_AssetExtProVehicles5 = new HashSet<GFI_AMM_AssetExtProVehicles>();
        }
    
        public int iID { get; set; }
        public string TypeName { get; set; }
        public string Field1Name { get; set; }
        public string Field1Label { get; set; }
        public string Field1Type { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string sDataSource { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GFI_AMM_AssetExtProVehicles> GFI_AMM_AssetExtProVehicles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GFI_AMM_AssetExtProVehicles> GFI_AMM_AssetExtProVehicles1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GFI_AMM_AssetExtProVehicles> GFI_AMM_AssetExtProVehicles2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GFI_AMM_AssetExtProVehicles> GFI_AMM_AssetExtProVehicles3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GFI_AMM_AssetExtProVehicles> GFI_AMM_AssetExtProVehicles4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GFI_AMM_AssetExtProVehicles> GFI_AMM_AssetExtProVehicles5 { get; set; }
    }
}
