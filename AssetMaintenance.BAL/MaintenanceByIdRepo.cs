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
        public AssetMaintenanceDetailDto getAssetMaintenanceDetail(int id)
        {
            // Will query Database once we have structure ready
            var result = dbCon.GFI_AMM_VehicleMaintTypesLink.Where(c => c.URI == id).Select(c=> new AssetMaintenanceDetailDto
            {
                URI=c.URI,
                Asset =  dbCon.GFI_FLT_Asset.FirstOrDefault(d=> d.AssetID == c.AssetId).AssetName,
                Maintenance = dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d=> d.MaintTypeId== c.MaintTypeId).Description,
                AssetNo= dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == c.AssetId).AssetNumber,
                Reminder= (DateTime)dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d=> d.MaintTypeId == c.Status).OccurrenceFixedDate,
                NextMaintenance=(DateTime)c.NextMaintDate,
                Category= dbCon.GFI_AMM_VehicleMaintCat.FirstOrDefault(d=> d.MaintCatId == dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(s=> s.MaintTypeId==c.MaintTypeId).MaintCatId_cbo).Description
            }).SingleOrDefault();
            ///List<GFI_AMM_VehicleMaintenance> lst= new MaintenanceListByStatus().getMaintenanceListByStatus(5);            
            //var result = new List<MaintenanceByStatusListDto> {
            //    new MaintenanceByStatusListDto {
            //        AssetNo ="372 JN 102",
            //        Asset="Car",
            //        Maintenance ="Insurance",
            //        NextMaintenance =DateTime.Now.AddDays(10),
            //        Reminder =DateTime.Now.AddDays(2)
            //    },
            //     new MaintenanceByStatusListDto {
            //        AssetNo ="555 JN 102",
            //        Asset="Transformer",
            //        Maintenance ="Servicing",
            //        NextMaintenance =DateTime.Now.AddDays(100),
            //        Reminder =DateTime.Now.AddDays(20)
            //    },
            //      new MaintenanceByStatusListDto {
            //        AssetNo ="372 JN 102",
            //        Asset="Lorry",
            //        Maintenance ="Servicing",
            //        NextMaintenance =DateTime.Now.AddDays(50),
            //        Reminder =DateTime.Now.AddDays(30)
            //    }

            //};
            return result;
        }

    }
}
