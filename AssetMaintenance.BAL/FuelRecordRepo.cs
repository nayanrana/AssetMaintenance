using AssetMaintenance.BAL.DTO;
using AssetMaintenance.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMaintenance.BAL
{
    public class FuelRecordRepo
    {
        AssetMaintenanceEntities dbCon;

        public FuelRecordRepo()
        {
            dbCon = new AssetMaintenanceEntities();
        }

        public List<FuelRecordDto> getAllFuelRecords()
        {
            var fuelList = dbCon.Fuel_Record.AsEnumerable().Select(x => new FuelRecordDto
            {
                Id = x.Id,
                FillingStation = x.FillingStation,
                PeriodFrom = x.PeriodFrom,
                PeriodTo = x.PeriodTo,
                AmountExclVat = x.AmountExclVat,
                AmountIncVat = x.AmountIncVat,
                ClaimNumber = x.ClaimNumber,
                DiscountAmount = x.DiscountAmount,
                FuelType = x.FuelType,
                QuantityLitre = x.QuantityLitre,
                VatAmount = x.VatAmount,
                VoucherNumber = x.VoucherNumber,
                Is_PaymentReceiptGenerate = x.Is_PaymentReceiptGenerate
            });
            return fuelList.ToList();
        }

        public int InsertFuelRecord(FuelRecordDto fuel)
        {
            try
            {
                Fuel_Record ful = new Fuel_Record();
                ful.FillingStation = fuel.FillingStation;
                ful.PeriodFrom = fuel.PeriodFrom;
                ful.PeriodTo = fuel.PeriodTo;
                ful.Is_PaymentReceiptGenerate = fuel.Is_PaymentReceiptGenerate;
                ful.VoucherNumber = fuel.VoucherNumber;
                ful.AmountExclVat = fuel.AmountExclVat;
                ful.AmountIncVat = fuel.AmountIncVat;
                ful.ClaimNumber = fuel.ClaimNumber;
                ful.DiscountAmount = fuel.DiscountAmount;
                ful.FuelType = fuel.FuelType;
                ful.QuantityLitre = fuel.QuantityLitre;
                ful.VatAmount = fuel.VatAmount;
                ful.VoucherNumber = fuel.VoucherNumber;

                dbCon.Fuel_Record.Add(ful);
                dbCon.SaveChanges();
                return ful.Id;

            }
            catch (Exception)
            {
                throw;
                return 0;
            }
        }

        public FuelRecordDto getFuelManagerByID(int fuelmanagetid)
        {
            if (fuelmanagetid > 0)
            {
                var fuelmanagerResult = dbCon.Fuel_Record.Where(x => x.Id == fuelmanagetid).Select(x => new FuelRecordDto
                {

                    Id = x.Id,
                    FillingStation = x.FillingStation,
                    PeriodFrom = x.PeriodFrom,
                    PeriodTo = x.PeriodTo,
                    AmountExclVat = x.AmountExclVat,
                    AmountIncVat = x.AmountIncVat,
                    ClaimNumber = x.ClaimNumber,
                    DiscountAmount = x.DiscountAmount,
                    FuelType = x.FuelType,
                    QuantityLitre = x.QuantityLitre,
                    VatAmount = x.VatAmount,
                    VoucherNumber = x.VoucherNumber,
                    Is_PaymentReceiptGenerate = x.Is_PaymentReceiptGenerate

                }).FirstOrDefault();
                return fuelmanagerResult;
            }
            else
            {

                return new FuelRecordDto();
            }


        }

        public bool updateFuelRecord(FuelRecordDto fuel)
        {
            try
            {
                var ful = dbCon.Fuel_Record.Where(x => x.Id == fuel.Id).FirstOrDefault();
                ful.FillingStation = fuel.FillingStation;
                ful.PeriodFrom = fuel.PeriodFrom;
                ful.PeriodTo = fuel.PeriodTo;
                ful.Is_PaymentReceiptGenerate = fuel.Is_PaymentReceiptGenerate;
                ful.VoucherNumber = fuel.VoucherNumber;
                ful.AmountExclVat = fuel.AmountExclVat;
                ful.AmountIncVat = fuel.AmountIncVat;
                ful.ClaimNumber = fuel.ClaimNumber;
                ful.DiscountAmount = fuel.DiscountAmount;
                ful.FuelType = fuel.FuelType;
                ful.QuantityLitre = fuel.QuantityLitre;
                ful.VatAmount = fuel.VatAmount;
                ful.VoucherNumber = fuel.VoucherNumber;

                dbCon.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public string deleteFuelManagement(int id)
        {
            dbCon.FuelRecord_Detail.RemoveRange(dbCon.FuelRecord_Detail.Where(k => k.FuelRecordId == id).ToList());
            dbCon.SaveChanges();
            Fuel_Record fuelDelete = dbCon.Fuel_Record.SingleOrDefault(c => c.Id == id);

            dbCon.Fuel_Record.Remove(fuelDelete);
            dbCon.SaveChanges();
            return "Data Deleted successfully.";
        }

        public bool CheckVoucherNumber(FuelRecordDto fuel)
        {
           return dbCon.Fuel_Record.Any(x => x.VoucherNumber == fuel.VoucherNumber );
        }

    }
}
