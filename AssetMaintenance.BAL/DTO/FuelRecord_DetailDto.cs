using System;

namespace AssetMaintenance.BAL.DTO
{
    public class FuelRecord_DetailDto
    {
        public long FuelRecord_DetailId { get; set; }
        public int FuelRecordId { get; set; }
        public DateTime? Date { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string VoucherNumber { get; set; }
        public string CostCentreLocation { get; set; }
        public string RegistrationNo { get; set; }
        public string FillingStation { get; set; }
        public string Driver { get; set; }
        public string FuelType { get; set; }
        public int QuantityLitres { get; set; }
        public int? ActualMilage { get; set; }
        public int? CurrentMilage { get; set; }
        public Nullable<double> AmountExVal { get; set; }
        public Nullable<double> DiscountAmount { get; set; }
        public Nullable<double> VatAmount { get; set; }
        public double? AmountInVal { get; set; }
        public string NameFillingStation { get; set; }
    }
}
