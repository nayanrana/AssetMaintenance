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
            int[] statuslst = new int[4];

            //statuslst[0] = maintenanceStatus; }
            var result = dbCon.GFI_AMM_VehicleMaintenance
                    .Where(c => c.MaintStatusId_cbo == maintenanceStatus)
                   // .Join(dbCon.GFI_FLT_Asset, vm => vm.AssetId, a => a.AssetID, (vm, a) => new { Vm = vm, A = a })
                    .OrderByDescending(c => c.URI)
                   ///.GroupBy(p => p.AssetId)
                   .Select(g =>
                   new MaintenanceByStatusListDto
                   {
                       AssetID = (int)g.AssetId,
                       URI = (int)g.URI,   //g.FirstOrDefault(c => c.AssetId == g.Key).URI,
                       Asset = dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == g.AssetId).AssetName,
                       AssetNo = dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == g.AssetId).AssetNumber,
                       NextMaintenance = (DateTime)dbCon.GFI_AMM_VehicleMaintTypesLink.FirstOrDefault(c => c.AssetId == g.AssetId).NextMaintDate,
                       Maintenance = dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d => d.MaintTypeId == g.MaintTypeId_cbo).Description,
                       MaintenanceStatus = dbCon.GFI_AMM_VehicleMaintStatus.FirstOrDefault(d => d.MaintStatusId == g.MaintStatusId_cbo).Description,
                       MaintenanceID = (int)g.MaintStatusId_cbo,   //FirstOrDefault(c => c.AssetId == g.Key).Status,
                       Reminder = (DateTime)dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d => d.MaintTypeId == g.MaintTypeId_cbo).OccurrenceFixedDate,
                   }).ToList();
            // Will query Database once we have structure ready
            return result;

        }

        public List<MaintenanceByStatusListDto> getAllMaintenanceByStatusList(int maintenanceStatus)
        {
            int[] statuslst = new int[6];
            if (maintenanceStatus == 0)
            {
                statuslst[0] = 1; statuslst[1] = 2; statuslst[2] = 3; statuslst[3] = 7; statuslst[4] = 5; statuslst[5] = 6;
                var result = dbCon.GFI_AMM_VehicleMaintenance
                    .Where(c => statuslst.Contains((int)c.MaintStatusId_cbo))
                    .OrderByDescending(c => c.URI)
                   .Select(g =>
                   new MaintenanceByStatusListDto
                   {
                       AssetID = (int)g.AssetId,
                       URI = (int)g.URI,
                       Asset = dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == g.AssetId).AssetName,
                       AssetNo = dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == g.AssetId).AssetNumber,
                       NextMaintenance = (DateTime?)g.StartDate,
                       Maintenance = dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d => d.MaintTypeId == g.MaintTypeId_cbo).Description,
                       MaintenanceStatus = dbCon.GFI_AMM_VehicleMaintStatus.FirstOrDefault(d => d.MaintStatusId == g.MaintStatusId_cbo).Description,
                       MaintenanceID = (int?)g.MaintStatusId_cbo,
                       Reminder = (DateTime?)dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d => d.MaintTypeId == g.MaintTypeId_cbo).OccurrenceFixedDate,
                   }).ToList();
                return result;
            }
            else
            {
                //statuslst[0] = maintenanceStatus; }
                var result = dbCon.GFI_AMM_VehicleMaintenance
                    .Where(c => c.MaintStatusId_cbo == maintenanceStatus)
                    .OrderByDescending(c => c.URI)
                    .Select(g =>
                   new MaintenanceByStatusListDto
                   {
                       URI = (int)g.URI,
                       Asset = dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == g.AssetId).AssetName,
                       AssetNo = dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == g.AssetId).AssetNumber,
                       NextMaintenance = (DateTime?)g.StartDate,
                       Maintenance = dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d => d.MaintTypeId == g.MaintTypeId_cbo).Description,
                       MaintenanceStatus = dbCon.GFI_AMM_VehicleMaintStatus.FirstOrDefault(d => d.MaintStatusId == g.MaintStatusId_cbo).Description,
                       MaintenanceID = (int?)g.MaintStatusId_cbo,
                       Reminder = (DateTime?)dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d => d.MaintTypeId == g.MaintTypeId_cbo).OccurrenceFixedDate,
                   }).ToList();
                // Will query Database once we have structure ready
                return result;

            }
        }
    }
}
