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
                Id=x.Id,
                FillingStation=x.FillingStation,
                Period=x.Period,
                RegistrationNo=x.RegistrationNo,
                FuelInvoice=x.FuelInvoice,
                BatchNo=x.BatchNo,
                RetailPrice=x.RetailPrice,
                Discount=x.Discount,
                TotalAmount=x.TotalAmount
            });
            return fuelList.ToList();
        }

        public string InsertFuelRecord(FuelRecordDto fuel)
        {
            Fuel_Record ful = new Fuel_Record();
            ful.FillingStation = fuel.FillingStation;
            ful.Period = fuel.Period;
            ful.RegistrationNo = fuel.RegistrationNo;
            ful.FuelInvoice = fuel.FuelInvoice;
            ful.BatchNo = fuel.BatchNo;
            ful.RetailPrice = fuel.RetailPrice;
            ful.Discount = fuel.Discount;
            ful.TotalAmount = fuel.TotalAmount;
            dbCon.Fuel_Record.Add(ful);
            dbCon.SaveChanges();
            return "fuel record inserted."; 
        }
    }
}
