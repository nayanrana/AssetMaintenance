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
    
    public partial class GFI_GasolineDetail
    {
        public long Gasolineld { get; set; }
        public double Price { get; set; }
        public int SupplierId { get; set; }
        public System.DateTime Date { get; set; }
        public double Discount { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public bool Status { get; set; }
    
        public virtual Supplier Supplier { get; set; }
    }
}
