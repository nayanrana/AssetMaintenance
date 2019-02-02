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
        public bool InsertFuelRecordDetail(List<FuelRecord_DetailDto> lstFuelRecodDto, int fuelId)
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
                    objFuelDetails.AmountInVal = item.AmountInVal.HasValue ? item.AmountInVal.Value : 0;
                    objFuelDetails.CurrentMilage = item.CurrentMilage;
                    objFuelDetails.Date = item.Date.HasValue ? item.Date.Value : System.DateTime.Now; 
                    objFuelDetails.DateCreated = item.DateCreated;
                    objFuelDetails.Driver = item.Driver;
                    objFuelDetails.FillingStation = item.FillingStation;
                    objFuelDetails.FuelType = item.FuelType;
                    objFuelDetails.QuantityLitres = item.QuantityLitres;
                    objFuelDetails.VatAmount = item.VatAmount;
                    objFuelDetails.VoucherNumber = item.VoucherNumber;
                    objFuelDetails.CostCentreLocation = item.CostCentreLocation;
                    objFuelDetails.DiscountAmount = item.DiscountAmount;
                    objFuelDetails.RegistrationNo = string.IsNullOrEmpty(item.RegistrationNo) ? string.Empty : item.RegistrationNo;
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

        public List<FuelRecord_DetailDto> getFuelDetails(int fuelid)
        {
            var fueldetails = dbCon.FuelRecord_Detail.Where(k => k.FuelRecordId == fuelid).Select(k => new FuelRecord_DetailDto
            {
                FuelRecord_DetailId = k.FuelRecord_DetailId,
                FuelRecordId = k.FuelRecordId,
                Date = k.Date,
                DateCreated = k.DateCreated,
                VoucherNumber = k.VoucherNumber,
                CostCentreLocation = k.CostCentreLocation,
                RegistrationNo = k.RegistrationNo,
                FillingStation = k.FillingStation,
                Driver = k.Driver,
                FuelType = k.FuelType,
                QuantityLitres = k.QuantityLitres,
                ActualMilage = k.ActualMilage,
                CurrentMilage = k.CurrentMilage,
                AmountExVal = k.AmountExVal,
                DiscountAmount = k.DiscountAmount,
                VatAmount = k.VatAmount,
                AmountInVal = k.AmountInVal   
            }).ToList();

            return fueldetails;
        }

        public FuelRecord_DetailDto getFuelDetailsByid(Int64 fuleldetailid)
        {
            var fueldetails = dbCon.FuelRecord_Detail.Where(k => k.FuelRecord_DetailId == fuleldetailid).Select(k => new FuelRecord_DetailDto
            {
                FuelRecord_DetailId = k.FuelRecord_DetailId,
                FuelRecordId = k.FuelRecordId,
                Date = k.Date,
                DateCreated = k.DateCreated,
                VoucherNumber = k.VoucherNumber,
                CostCentreLocation = k.CostCentreLocation,
                RegistrationNo = k.RegistrationNo,
                FillingStation = k.FillingStation,
                Driver = k.Driver,
                FuelType = k.FuelType,
                QuantityLitres = k.QuantityLitres,
                ActualMilage = k.ActualMilage,
                CurrentMilage = k.CurrentMilage,
                AmountExVal = k.AmountExVal,
                DiscountAmount = k.DiscountAmount,
                VatAmount = k.VatAmount,
                AmountInVal = k.AmountInVal
            }).FirstOrDefault();

            return fueldetails;

        }

        public bool updateFuelRecordManual(FuelRecord_DetailDto fuelmanual)
        {
            try
            {
                var fuelmanagerResult = dbCon.FuelRecord_Detail.Where(x => x.FuelRecord_DetailId == fuelmanual.FuelRecord_DetailId).FirstOrDefault();
                fuelmanagerResult.FillingStation = fuelmanual.FillingStation;
                fuelmanagerResult.Driver = fuelmanual.Driver;
                fuelmanagerResult.ActualMilage = fuelmanual.ActualMilage;
                fuelmanagerResult.CurrentMilage = fuelmanual.CurrentMilage;
                fuelmanagerResult.RegistrationNo = string.IsNullOrEmpty(fuelmanual.RegistrationNo) ? string.Empty : fuelmanual.RegistrationNo;

                
                fuelmanagerResult.Date = fuelmanual.Date.HasValue ? fuelmanual.Date.Value : System.DateTime.Now; 
                fuelmanagerResult.DateCreated = fuelmanual.DateCreated;
                fuelmanagerResult.VoucherNumber = fuelmanual.VoucherNumber;
                fuelmanagerResult.CostCentreLocation = fuelmanual.CostCentreLocation;
                fuelmanagerResult.RegistrationNo = fuelmanual.RegistrationNo;
                fuelmanagerResult.FillingStation = fuelmanual.FillingStation;
                fuelmanagerResult.Driver = fuelmanual.Driver;
                fuelmanagerResult.FuelType = fuelmanual.FuelType;
                fuelmanagerResult.QuantityLitres = fuelmanual.QuantityLitres;
                fuelmanagerResult.ActualMilage = fuelmanual.ActualMilage;
                fuelmanagerResult.CurrentMilage = fuelmanual.CurrentMilage;
                fuelmanagerResult.AmountExVal = fuelmanual.AmountExVal;
                fuelmanagerResult.DiscountAmount = fuelmanual.DiscountAmount;
                fuelmanagerResult.VatAmount = fuelmanual.VatAmount;
                fuelmanagerResult.AmountInVal = fuelmanual.AmountInVal.HasValue ? fuelmanual.AmountInVal.Value : 0;

                dbCon.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public object deleteFuelRecord(int id)
        {
            FuelRecord_Detail fuelDelete = dbCon.FuelRecord_Detail.SingleOrDefault(c => c.FuelRecord_DetailId == id);
            dbCon.FuelRecord_Detail.Remove(fuelDelete);
            dbCon.SaveChanges();
            return "Data Deleted successfully.";
        }
    }
}
