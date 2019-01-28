using System;

namespace AssetMaintenance.BAL.DTO
{
    public class FuelRecord_DetailDto
    {
        public long FuelRecord_DetailId { get; set; }
        public int FuelRecordId { get; set; }
        public System.DateTime Date { get; set; }
        public string VoucherNo { get; set; }
        public string RegistrationNo { get; set; }
        public string FillingStation { get; set; }
        public string Driver { get; set; }
        public string FuelType { get; set; }
        public int Quantities { get; set; }
        public int? ActualMilage { get; set; }
        public int? CurrentMilage { get; set; }
        public Nullable<double> AmountExVal { get; set; }
        public Nullable<double> Discount { get; set; }
        public Nullable<double> VatAmount { get; set; }
        public double? AmountInVal { get; set; }
    }
}
