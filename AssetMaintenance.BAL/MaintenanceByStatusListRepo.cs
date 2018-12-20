using AssetMaintenance.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using AssetMaintenance.DAL;
using System.Linq;

namespace AssetMaintenance.BAL
{
    public class MaintenanceByStatusListRepo
    {
        AssetMaintenanceEntities dbCon = new AssetMaintenanceEntities();
        public List<MaintenanceByStatusListDto> getMaintenanceByStatusList(int maintenanceStatus)
        {
            // Will query Database once we have structure ready
            var result = dbCon.GFI_AMM_VehicleMaintTypesLink
                    .Where(c=> c.Status==maintenanceStatus)
                   .GroupBy(p => p.AssetId)
                   .Select(g => 
                   new MaintenanceByStatusListDto {
                       URI=(int)g.Key,
                       Asset = dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == g.Key).AssetName,
                       AssetNo = dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == g.Key).AssetNumber,
                       NextMaintenance = (DateTime)g.FirstOrDefault(c=> c.AssetId ==g.Key).NextMaintDate,
                       Maintenance = dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d => d.MaintTypeId == g.FirstOrDefault(c => c.AssetId == g.Key).MaintTypeId).Description,
                       Reminder = (DateTime)dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d => d.MaintTypeId == g.FirstOrDefault(c => c.AssetId == g.Key).MaintTypeId).OccurrenceFixedDate,
                   }).ToList();



            //var result = dbCon.GFI_AMM_VehicleMaintTypesLink.Where(c => c.Status == maintenanceStatus).Select(c=> new MaintenanceByStatusListDto {
            //    URI=0,
            //    Asset =  dbCon.GFI_FLT_Asset.FirstOrDefault(d=> d.AssetID == c.AssetId).AssetName,
            //    Maintenance = dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d=> d.MaintTypeId== c.MaintTypeId).Description,
            //    AssetNo= dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == c.AssetId).AssetNumber,
            //    Reminder= (DateTime)dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d=> d.MaintTypeId == c.Status).OccurrenceFixedDate,
            //    NextMaintenance=(DateTime)c.NextMaintDate
            //}).ToList();
             
            return result;
        }

    }
}
