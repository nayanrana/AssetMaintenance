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
                PeriodTo=x.PeriodTo,
                
                //FuelInvoice = x.FuelInvoice,
                //BatchNo = x.BatchNo,
                //RetailPrice = x.RetailPrice,
                //Discount = x.Discount,
                //TotalAmount = x.TotalAmount,
                Is_PaymentReceiptGenerate=x.Is_PaymentReceiptGenerate
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
                //ful.RegistrationNo = fuel.RegistrationNo;
                //ful.FuelInvoice = fuel.FuelInvoice;
                //ful.BatchNo = fuel.BatchNo;
                //ful.RetailPrice = fuel.RetailPrice;
                //ful.Discount = fuel.Discount;
                //ful.TotalAmount = fuel.TotalAmount;
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
            if (fuelmanagetid>0)
            {
                var fuelmanagerResult = dbCon.Fuel_Record.Where(x => x.Id == fuelmanagetid).Select(x => new FuelRecordDto
                {

                    Id = x.Id,
                    FillingStation = x.FillingStation,
                    PeriodFrom = x.PeriodFrom,
                    PeriodTo = x.PeriodTo,
                    //RegistrationNo = x.RegistrationNo,
                    //FuelInvoice = x.FuelInvoice ?? 0,
                    //BatchNo = x.BatchNo,
                    //RetailPrice = x.RetailPrice,
                    //Discount = x.Discount ?? 0,
                    //TotalAmount = x.TotalAmount

                }).FirstOrDefault();
                return fuelmanagerResult;
            }
            else
            {
               
                return new FuelRecordDto();
            }
            
            
        }

        public bool updateFuelRecord(FuelRecordDto model)
        {
            try
            {
                var fuelmanagerResult = dbCon.Fuel_Record.Where(x => x.Id == model.Id).FirstOrDefault();
                //fuelmanagerResult.BatchNo = model.BatchNo;
                fuelmanagerResult.FillingStation = model.FillingStation;
                fuelmanagerResult.PeriodFrom = model.PeriodFrom;
                fuelmanagerResult.PeriodTo = model.PeriodTo;
                //fuelmanagerResult.RegistrationNo = model.RegistrationNo;
                //fuelmanagerResult.FuelInvoice = model.FuelInvoice;
                //fuelmanagerResult.RetailPrice = model.RetailPrice;
                //fuelmanagerResult.Discount = model.Discount;
                //fuelmanagerResult.TotalAmount = model.TotalAmount;
                fuelmanagerResult.Is_PaymentReceiptGenerate = model.Is_PaymentReceiptGenerate;

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

       
    }
}
