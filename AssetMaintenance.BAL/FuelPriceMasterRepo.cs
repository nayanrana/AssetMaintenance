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
        public List<FuelMasterDto> GetFuelDetail(int Id=0)
        {
            var fuelList = (from x in dbCon.GFI_FuelDetail
                            join sup in dbCon.Suppliers on x.SupplierId equals sup.Id
                            select new FuelMasterDto
                            {
                                Price = x.Price,
                                Discount = x.Discount,
                                FuelId = x.FuelId,
                                PriceDate = x.Date,
                                CreatedBy = x.CreatedBy,
                                SupplierId = x.SupplierId,
                                SupplierName = sup.Name,

                            }).Where(x=>Id==0||x.SupplierId==Id).ToList();

            return fuelList;
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
                tblGFI_FuelDetail.Status = true;
                tblGFI_FuelDetail.SupplierId = objFuelMasterDto.SupplierId;
                dbCon.GFI_FuelDetail.Add(tblGFI_FuelDetail);
                dbCon.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Get List of Fuel Details And Fill in MOdel
        /// </summary>
        /// <returns></returns>
        public List<FuelMasterDto> GetDisellDetail(int Id=0)
        {
            var fuelList = (from x in dbCon.GFI_DieselDetail
                            join sup in dbCon.Suppliers on x.SupplierId equals sup.Id
                            select new FuelMasterDto
                            {
                                Price = x.Price,
                                Discount = x.Discount,
                                FuelId = x.Dieselld,
                                PriceDate = x.Date,
                                CreatedBy = x.CreatedBy,
                                SupplierId = x.SupplierId,
                                SupplierName = sup.Name,

                            }).Where(x => Id == 0 || x.SupplierId == Id).ToList();
            return fuelList;
        }

        /// <summary>
        /// Insert New Entry in Fuel Price Details DB Table
        /// </summary>
        /// <param name="objFuelMasterDto">Object of Model</param>
        /// <returns>Success Or Failure</returns>
        public bool InsertDiselRecord(FuelMasterDto objFuelMasterDto)
        {
            try
            {
                GFI_DieselDetail tblGFI_DieselDetail = new GFI_DieselDetail();
                tblGFI_DieselDetail.Price = objFuelMasterDto.Price;
                tblGFI_DieselDetail.Discount = objFuelMasterDto.Discount;
                tblGFI_DieselDetail.Date = objFuelMasterDto.PriceDate;
                tblGFI_DieselDetail.CreatedBy = objFuelMasterDto.CreatedBy;
                tblGFI_DieselDetail.CreatedOn = DateTime.Now;
                tblGFI_DieselDetail.Status = true;
                tblGFI_DieselDetail.SupplierId = objFuelMasterDto.SupplierId;

                dbCon.GFI_DieselDetail.Add(tblGFI_DieselDetail);
                dbCon.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Get List of Fuel Details And Fill in MOdel
        /// </summary>
        /// <returns></returns>
        public List<FuelMasterDto> GetGasolineDetail(int Id=0)
        {
            var fuelList = (from x in dbCon.GFI_GasolineDetail
                            join sup in dbCon.Suppliers on x.SupplierId equals sup.Id
                            select new FuelMasterDto
                            {
                                Price = x.Price,
                                Discount = x.Discount,
                                FuelId = x.Gasolineld,
                                PriceDate = x.Date,
                                CreatedBy = x.CreatedBy,
                                SupplierId = x.SupplierId,
                                SupplierName = sup.Name,

                            }).Where(x => Id == 0 || x.SupplierId == Id).ToList();
            return fuelList;
        }

        /// <summary>
        /// Insert New Entry in Fuel Price Details DB Table
        /// </summary>
        /// <param name="objFuelMasterDto">Object of Model</param>
        /// <returns>Success Or Failure</returns>
        public bool InsertGasolineRecord(FuelMasterDto objFuelMasterDto)
        {
            try
            {
                GFI_GasolineDetail tblGFI_GasolineDetail = new GFI_GasolineDetail();
                tblGFI_GasolineDetail.Price = objFuelMasterDto.Price;
                tblGFI_GasolineDetail.Discount = objFuelMasterDto.Discount;
                tblGFI_GasolineDetail.Date = objFuelMasterDto.PriceDate;
                tblGFI_GasolineDetail.CreatedBy = objFuelMasterDto.CreatedBy;
                tblGFI_GasolineDetail.CreatedOn = DateTime.Now;
                tblGFI_GasolineDetail.Status = true;
                tblGFI_GasolineDetail.SupplierId = objFuelMasterDto.SupplierId;

                dbCon.GFI_GasolineDetail.Add(tblGFI_GasolineDetail);

                dbCon.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<KeyValuePair<string, int>> GetSupplierName()
        {
            List<KeyValuePair<string, int>> lstKeyValue = new List<KeyValuePair<string, int>>();

            lstKeyValue = (dbCon.Suppliers.AsEnumerable().Where(x => x.IsFuel == true).Select(x =>
                               new KeyValuePair<string, int>
                               (
                                  x.Name,
                                 x.Id
                               )).ToList());
            return lstKeyValue;
        }
    }
}
