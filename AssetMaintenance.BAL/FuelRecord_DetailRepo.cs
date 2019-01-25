using AssetMaintenance.BAL.DTO;
using AssetMaintenance.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetMaintenance.BAL
{
   public class FuelRecord_DetailRepo
    {
        AssetMaintenanceEntities dbCon;

        public FuelRecord_DetailRepo()
        {
            dbCon = new AssetMaintenanceEntities();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstFuelRecodDto"></param>
        /// <returns></returns>
        public bool InsertFuelRecordDetail(List<FuelRecord_DetailDto> lstFuelRecodDto,int fuelId)
        {
            try
            {
                FuelRecord_Detail objFuelDetails;
                //dbCon.FuelRecord_Detail.RemoveRange(dbCon.FuelRecord_Detail.Where(k => k.FuelRecordId == fuelId).ToList());
                //dbCon.SaveChanges();

                foreach (var item in lstFuelRecodDto)
                {
                    objFuelDetails = new FuelRecord_Detail();
                    objFuelDetails.FuelRecordId = fuelId;
                    objFuelDetails.ActualMilage = item.ActualMilage;
                    objFuelDetails.AmountExVal = item.AmountExVal;
                    objFuelDetails.AmountInVal = item.AmountInVal;
                    objFuelDetails.CurrentMilage = item.CurrentMilage;
                    objFuelDetails.Date = item.Date;
                    objFuelDetails.Discount = item.Discount;
                    objFuelDetails.Driver = item.Driver;
                    objFuelDetails.FillingStation = item.FillingStation;
                   
                    objFuelDetails.FuelType = item.FuelType;
                    objFuelDetails.Quantities = item.Quantities;
                    objFuelDetails.VatAmount = item.VatAmount;
                    objFuelDetails.VoucherNo = item.VoucherNo;
                    objFuelDetails.RegistrationNo = item.RegistrationNo;
                    dbCon.FuelRecord_Detail.Add(objFuelDetails);
                }
                dbCon.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool InsertFuelRecordDetailManual(List<FuelRecordManualDto> lstFuelRecodDto, int fuelId)
        {
            try
            {
                //dbCon.FuelRecord_Detail.RemoveRange(dbCon.FuelRecord_Detail.Where(k => k.FuelRecordId == fuelId).ToList());
                //dbCon.SaveChanges();
                FuelRecord_Detail objFuelDetails;
                foreach (var item in lstFuelRecodDto)
                {
                    objFuelDetails = new FuelRecord_Detail();
                    objFuelDetails.FuelRecordId = fuelId;
                  
                    objFuelDetails.AmountExVal = item.Amount;
                    objFuelDetails.AmountInVal = item.AmountInc.HasValue?item.AmountInc.Value:0;
                    
                    objFuelDetails.Date = item.Date;
                    objFuelDetails.Discount = item.DiscountAmount;
                  
                    objFuelDetails.FillingStation = item.FillingStation;

                    objFuelDetails.FuelType = item.FuelType;
                    objFuelDetails.Quantities = item.QuantityLitre;
                    objFuelDetails.VatAmount = item.VatAmount;
                    objFuelDetails.VoucherNo = item.VoucherNumber;
                    objFuelDetails.RegistrationNo = "";
                    dbCon.FuelRecord_Detail.Add(objFuelDetails);
                }
                dbCon.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       

        public List<FuelRecordManualDto> getFuelDetails(int fuelid)
        {
            var fueldetails = dbCon.FuelRecord_Detail.Where(k => k.FuelRecordId == fuelid).Select(k => new FuelRecordManualDto
            {
                  Amount = k.AmountExVal,
                  AmountInc = k.AmountInVal,
                  Date = k.Date,
                  DiscountAmount = k.Discount,
                  FillingStation = k.FillingStation,
                  FuelType = k.FuelType,
                  QuantityLitre = k.Quantities,
                  VatAmount = k.VatAmount,
                  VoucherNumber = k.VoucherNo,
                  Id= k.FuelRecord_DetailId
                

            }).ToList();

            return fueldetails;
        }
       public FuelRecordManualDto getFuelDetailsByid (Int64 fuleldetailid)
        {
            var fueldetails = dbCon.FuelRecord_Detail.Where(k => k.FuelRecord_DetailId == fuleldetailid).Select(k => new FuelRecordManualDto
            {
               
                Amount = k.AmountExVal,
                AmountInc = k.AmountInVal,
                Date = k.Date,
                DiscountAmount = k.Discount,
                FillingStation = k.FillingStation,
                FuelType = k.FuelType,
                QuantityLitre = k.Quantities,
                VatAmount = k.VatAmount,
                VoucherNumber = k.VoucherNo,
                Id = k.FuelRecord_DetailId


            }).FirstOrDefault();

            return fueldetails;

        }

        public bool updateFuelRecordManual(FuelRecordManualDto fuelmanual)
        {
            try
            {
                var fuelmanagerResult = dbCon.FuelRecord_Detail.Where(x => x.FuelRecord_DetailId == fuelmanual.Id).FirstOrDefault();
                fuelmanagerResult.FillingStation = fuelmanual.FillingStation;
                fuelmanagerResult.AmountExVal = fuelmanual.Amount;
                fuelmanagerResult.AmountInVal = fuelmanual.AmountInc.HasValue ? fuelmanual.AmountInc.Value : 0;
                fuelmanagerResult.Date = fuelmanual.Date;
                fuelmanagerResult.Discount = fuelmanual.DiscountAmount;
                fuelmanagerResult.FuelType = fuelmanual.FuelType;
                fuelmanagerResult.Quantities = fuelmanual.QuantityLitre;
                fuelmanagerResult.VatAmount = fuelmanual.VatAmount;
                fuelmanagerResult.VoucherNo = fuelmanual.VoucherNumber;
                dbCon.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
       
    }
}
