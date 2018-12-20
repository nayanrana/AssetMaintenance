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
        public List<AssetMaintenanceDetailDto> getAssetMaintenanceDetail(int id)
        {
            // Will query Database once we have structure ready
            var result = dbCon.GFI_AMM_VehicleMaintTypesLink.Where(c => c.AssetId == id).Take(5).Select(c=> new AssetMaintenanceDetailDto
            {
                URI=c.URI,
                Asset =  dbCon.GFI_FLT_Asset.FirstOrDefault(d=> d.AssetID == c.AssetId).AssetName,
                Maintenance = dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d=> d.MaintTypeId== c.MaintTypeId).Description,
                AssetNo= dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == c.AssetId).AssetNumber,
                Reminder= (DateTime)dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d=> d.MaintTypeId == c.Status).OccurrenceFixedDate,
                NextMaintenance=(DateTime)c.NextMaintDate,
                Category= dbCon.GFI_AMM_VehicleMaintCat.FirstOrDefault(d=> d.MaintCatId == dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(s=> s.MaintTypeId==c.MaintTypeId).MaintCatId_cbo).Description
            }).ToList();
             
            return result;
        }

    }
}
