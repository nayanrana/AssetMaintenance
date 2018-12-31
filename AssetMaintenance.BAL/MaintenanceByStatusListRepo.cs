﻿using AssetMaintenance.BAL.DTO;
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
            if (maintenanceStatus == 0)
            {
                //statuslst[0] = 1; statuslst[1] = 2; statuslst[2] = 3; statuslst[3] = 7;
                var result = dbCon.GFI_AMM_VehicleMaintTypesLink
                   .Select(g =>
                   new MaintenanceByStatusListDto
                   {
                       URI = (int)g.URI,
                       Asset = dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == g.AssetId).AssetName,
                       AssetNo = dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == g.AssetId).AssetNumber,
                       NextMaintenance = (DateTime)g.NextMaintDate,
                       Maintenance = dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d => d.MaintTypeId == g.MaintTypeId).Description,
                       MaintenanceStatus = dbCon.GFI_AMM_VehicleMaintStatus.FirstOrDefault(d => d.MaintStatusId == g.Status).Description,
                       MaintenanceID = (int)g.Status,
                       Reminder = (DateTime)dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d => d.MaintTypeId == g.MaintTypeId).OccurrenceFixedDate,
                   }).ToList();
                return result;
            }
            else
            {
                //statuslst[0] = maintenanceStatus; }
                var result = dbCon.GFI_AMM_VehicleMaintTypesLink
                    ///.Where(c=> statuslst.Contains((int)c.Status))
                    .Where(c => c.Status == maintenanceStatus)
                    .OrderByDescending(c => c.URI)
                   .GroupBy(p => p.AssetId)
                   .Select(g =>
                   new MaintenanceByStatusListDto
                   {
                       URI = (int)g.Key,
                       Asset = dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == g.Key).AssetName,
                       AssetNo = dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == g.Key).AssetNumber,
                       NextMaintenance = (DateTime)g.FirstOrDefault(c => c.AssetId == g.Key).NextMaintDate,
                       Maintenance = dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d => d.MaintTypeId == g.FirstOrDefault(c => c.AssetId == g.Key).MaintTypeId).Description,
                       MaintenanceStatus = dbCon.GFI_AMM_VehicleMaintStatus.FirstOrDefault(d => d.MaintStatusId == g.FirstOrDefault(c => c.AssetId == g.Key).Status).Description,
                       MaintenanceID = (int)g.FirstOrDefault(c => c.AssetId == g.Key).Status,
                       Reminder = (DateTime)dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d => d.MaintTypeId == g.FirstOrDefault(c => c.AssetId == g.Key).MaintTypeId).OccurrenceFixedDate,
                   }).ToList();
                // Will query Database once we have structure ready
                return result;



                //var result = dbCon.GFI_AMM_VehicleMaintTypesLink.Where(c => c.Status == maintenanceStatus).Select(c=> new MaintenanceByStatusListDto {
                //    URI=0,
                //    Asset =  dbCon.GFI_FLT_Asset.FirstOrDefault(d=> d.AssetID == c.AssetId).AssetName,
                //    Maintenance = dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d=> d.MaintTypeId== c.MaintTypeId).Description,
                //    AssetNo= dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == c.AssetId).AssetNumber,
                //    Reminder= (DateTime)dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d=> d.MaintTypeId == c.Status).OccurrenceFixedDate,
                //    NextMaintenance=(DateTime)c.NextMaintDate
                //}).ToList();


            }
        }
    }
}
