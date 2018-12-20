using AssetMaintenance.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using AssetMaintenance.DAL;
using System.Linq;

namespace AssetMaintenance.BAL
{
    public class MaintenanceByIdRepo
    {
        AssetMaintenanceEntities dbCon = new AssetMaintenanceEntities();
        public List<AssetMaintenanceDetailDto> getAssetMaintenanceDetail(int id, int maintId)
        {
            // Will query Database once we have structure ready
            var result = dbCon.GFI_AMM_VehicleMaintenance.Where(c => c.AssetId == id && c.MaintTypeId_cbo == maintId).OrderByDescending(c => c.URI).Take(5).Select(c => new AssetMaintenanceDetailDto
            {
                URI = c.URI,
                Asset = dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == c.AssetId).AssetName,
                Maintenance = dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d => d.MaintTypeId == c.MaintTypeId_cbo).Description,
                ActualOdometer = c.ActualOdometer,
                ActualEngineHrs = c.ActualEngineHrs,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                Amount = c.TotalCost,
                ///AssetNo= dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == c.AssetId).AssetNumber,
                //Reminder= (DateTime)dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d=> d.MaintTypeId == c.MaintStatusId_cbo).OccurrenceFixedDate,
                //NextMaintenance=(DateTime)c.StartDate,
                ///Category= dbCon.GFI_AMM_VehicleMaintCat.FirstOrDefault(d=> d.MaintCatId == dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(s=> s.MaintTypeId==c.MaintTypeId_cbo).MaintCatId_cbo).Description
            }).ToList();

            return result;
        }

        public AssetMaintenanceDetailDto getAssetMaintenanceDetailbyID(int id, int maintId)
        {
            // Will query Database once we have structure ready
            var result = dbCon.GFI_AMM_VehicleMaintenance.Where(c => c.AssetId == id && c.MaintTypeId_cbo == maintId).OrderByDescending(c=> c.URI).Take(1).Select(c => new AssetMaintenanceDetailDto
            {
                URI = c.URI,
                Asset = dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == c.AssetId).AssetName,
                Maintenance = dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d => d.MaintTypeId == c.MaintTypeId_cbo).Description,
                ActualOdometer = c.ActualOdometer,
                ActualEngineHrs = c.ActualEngineHrs,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                Amount = c.TotalCost,
                AssetNo = dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == c.AssetId).AssetNumber,
                Reminder = (DateTime)dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d => d.MaintTypeId == c.MaintStatusId_cbo).OccurrenceFixedDate,
                NextMaintenance = (DateTime)c.StartDate,
                Category = dbCon.GFI_AMM_VehicleMaintCat.FirstOrDefault(d => d.MaintCatId == dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(s => s.MaintTypeId == c.MaintTypeId_cbo).MaintCatId_cbo).Description,
                ContactDetails=c.ContactDetails,
                CompanyName=c.CompanyName,
                PhoneNumber=c.PhoneNumber,
                CompanyRef=c.CompanyRef,

           
                          
            }).SingleOrDefault();

            return result;
        }
    }
}
