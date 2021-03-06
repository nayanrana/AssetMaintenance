﻿


using AssetMaintenance.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AssetMaintenance.BAL.DTO;
using AssetMaintenance.Helper;

namespace AssetMaintenance.BAL
{
    public class AssetMaintenanceRepo
    {
        AssetMaintenanceEntities dbCon = new AssetMaintenanceEntities();

        public List<KeyValuePair<int, string>> GetAssestDetails()
        {
            try
            {
                List<KeyValuePair<int, string>> lstKeyValue = new List<KeyValuePair<int, string>>();
                lstKeyValue = (dbCon.GFI_FLT_Asset.AsEnumerable().Select(x =>
                               new KeyValuePair<int, string>
                               (
                                  x.AssetID,
                                   x.AssetName
                               )).ToList());
                return lstKeyValue;

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<KeyValuePair<int, string>> GetMaintenanceDetails()
        {
            try
            {
                List<KeyValuePair<int, string>> lstKeyValue = new List<KeyValuePair<int, string>>();
                lstKeyValue = (dbCon.GFI_AMM_VehicleMaintTypes.AsEnumerable().Select(x =>
                              new KeyValuePair<int, string>
                              (
                                x.MaintTypeId,
                                  x.Description
                              )).ToList());

                return lstKeyValue;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool? SaveAssetMaintenance(int assestId, int maintenanceId)
        {
            try
            {
                if (!dbCon.AssetMaintenaceTypes.Any(x => x.AssetId == assestId && x.MaintenceId == maintenanceId))
                {
                    int statusId = dbCon.GFI_AMM_VehicleMaintStatus.FirstOrDefault(d => d.Description.ToLower() == "to schedule").MaintStatusId;
                    AssetMaintenaceType obj = new AssetMaintenaceType();
                    obj.AssetId = assestId;
                    obj.MaintenceId = maintenanceId;
                    dbCon.AssetMaintenaceTypes.Add(obj);

                    GFI_AMM_VehicleMaintenance gfiMaitenceType = new GFI_AMM_VehicleMaintenance();
                    gfiMaitenceType.AssetId = assestId;
                    gfiMaitenceType.MaintTypeId_cbo = maintenanceId;
                    gfiMaitenceType.MaintStatusId_cbo = statusId;
                    gfiMaitenceType.CreatedDate = DateTime.Now;
                    dbCon.GFI_AMM_VehicleMaintenance.Add(gfiMaitenceType);
                    dbCon.SaveChanges();
                    return true;
                }
                return null;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public MaintenanceTypeDto GetMaintenanceTypeDetailsById(int maintenanceTypeId)
        {
            var maintenanceTypeDetail = new MaintenanceTypeDto();
            maintenanceTypeDetail = dbCon.GFI_AMM_VehicleMaintTypes.
                                     Where(x => x.MaintTypeId == maintenanceTypeId).Select(x => new MaintenanceTypeDto
                                     {
                                         KMBasedAlertThreshold = x.OccurrenceKMTh ?? 0,
                                         KMBasedMaintenanceDue = x.OccurrenceKM ?? 0,
                                         EngineHrsBasedMaintenanceDue = x.OccurrenceEngineHrs ?? 0,
                                         EngineHrsBasedAlertThreshold = x.OccurrenceEngineHrsTh ?? 0,
                                         OccurrenceDuration = x.OccurrenceDuration ?? 0,
                                         OccurenceFixedDateThreshold = x.OccurrenceDurationTh ?? 0,
                                         MaintenanceTypeId = x.MaintTypeId
                                     })
                                     .FirstOrDefault();

            return maintenanceTypeDetail;
        }

        public List<AssetAndMaintenanceTypeAssignmentDto> GetAssetAndMaintenanceTypeDetailsByAssetId(int assetId)
        {
            var assetAndMaintenanceTypeAssignmentList = new List<AssetAndMaintenanceTypeAssignmentDto>();
            assetAndMaintenanceTypeAssignmentList = dbCon.AssetMaintenaceTypes.
                                     Where(x => x.AssetId == assetId)
                                     .Select(x => new AssetAndMaintenanceTypeAssignmentDto
                                     {
                                         AssetId = x.AssetId,
                                         MaintenanceTypeId = x.MaintenceId,
                                         AssetName = x.GFI_FLT_Asset.AssetName,
                                         MaintenanceTypeName = x.GFI_AMM_VehicleMaintTypes.Description,
                                         AssetMaintenanceId= x.AssetMaintenceId
                                     })
                                     .ToList();

            return assetAndMaintenanceTypeAssignmentList;
        }

        public bool deleteAssertMaintenance(int id)
        {
            var assetmaintenance = dbCon.GFI_AMM_VehicleMaintenance.Where(k => k.AssetId == id && k.UpdatedDate == null).FirstOrDefault();
            if(assetmaintenance == null)
            {
                return false;
            }
            else
            {
                dbCon.AssetMaintenaceTypes.Remove(dbCon.AssetMaintenaceTypes.Where(k => k.AssetMaintenceId == id).ToList().SingleOrDefault());
                dbCon.SaveChanges();
               
            }
            return true;
        }
    }
}
