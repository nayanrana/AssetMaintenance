using AssetMaintenance.BAL.DTO;
using AssetMaintenance.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetMaintenance.BAL
{
    public class FuelPriceMasterRepo
    {
        AssetMaintenanceEntities dbCon;

        public FuelPriceMasterRepo()
        {
            dbCon = new AssetMaintenanceEntities();
        }

        /// <summary>
        /// Get List of Fuel Details And Fill in MOdel
        /// </summary>
        /// <returns></returns>
        public List<FuelMasterDto> GetFuelDetail()
        {
            var fuelList = dbCon.GFI_FuelDetail.AsEnumerable().Select(x => new FuelMasterDto
            {
                Price = x.Price,
                Discount = x.Discount,
                FuelId = x.FuelId,
                PriceDate = x.Date,
                CreatedBy = x.CreatedBy,
            });
            return fuelList.ToList();
        }

        /// <summary>
        /// Insert New Entry in Fuel Price Details DB Table
        /// </summary>
        /// <param name="objFuelMasterDto">Object of Model</param>
        /// <returns>Success Or Failure</returns>
        public bool InsertFuelRecord(FuelMasterDto objFuelMasterDto)
        {
            try
            {
                GFI_FuelDetail tblGFI_FuelDetail = new GFI_FuelDetail();
                tblGFI_FuelDetail.Price = objFuelMasterDto.Price;
                tblGFI_FuelDetail.Discount = objFuelMasterDto.Discount;
                tblGFI_FuelDetail.Date = objFuelMasterDto.PriceDate;
                tblGFI_FuelDetail.CreatedBy = objFuelMasterDto.CreatedBy;
                tblGFI_FuelDetail.CreatedOn = DateTime.Now;
                dbCon.GFI_FuelDetail.Add(tblGFI_FuelDetail);
                dbCon.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
