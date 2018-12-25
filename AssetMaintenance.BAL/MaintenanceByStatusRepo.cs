using AssetMaintenance.BAL.DTO;
using System;
using AssetMaintenance.DAL;
using System.Linq;
using System.Collections.Generic;

namespace AssetMaintenance.BAL
{
    public class MaintenanceByStatusRepo
    {
        AssetMaintenanceEntities dbCon = new AssetMaintenanceEntities();
        //public List<MaintenanceByStatusDto> getMaintenanceByStatusCount()
        //{
        //    var model = dbCon.GFI_AMM_VehicleMaintStatus.AsEnumerable()
        //        .Where(c=> c.Description.ToLower() == "overdue" 
        //        || c.Description.ToLower() == "scheduled"
        //        || c.Description.ToLower() == "to schedule"
        //        || c.Description.ToLower() == "expired")
        //    .Select(x => new MaintenanceByStatusDto
        //    {
        //        Description =x.Description, ///dbCon.GFI_AMM_VehicleMaintStatus.FirstOrDefault(c => c.MaintStatusId == x.MaintStatusId).Description,
        //        NoofStatus = dbCon.GFI_AMM_VehicleMaintenance.Where(c => c.MaintStatusId_cbo == x.MaintStatusId).Count(),
        //        MaintStatusId=x.MaintStatusId
        //    }).ToList();

        //    return model;



        //}        


        public List<MaintenanceByStatusDto> getMaintenanceByStatusCount()
        {
            var model = dbCon.GFI_AMM_VehicleMaintStatus.AsEnumerable()
                .Where(c => c.Description.ToLower() == "overdue"
                || c.Description.ToLower() == "scheduled"
                || c.Description.ToLower() == "to schedule"
                || c.Description.ToLower() == "expired"
                || c.Description.ToLower() == "completed"
                || c.Description.ToLower() == "valid"
                )
            .Select(x => new MaintenanceByStatusDto
            {
                Description = x.Description, ///dbCon.GFI_AMM_VehicleMaintStatus.FirstOrDefault(c => c.MaintStatusId == x.MaintStatusId).Description,
                NoofStatus = dbCon.GFI_AMM_VehicleMaintenance.Where(c => c.MaintStatusId_cbo == x.MaintStatusId).Count(),
                MaintStatusId = x.MaintStatusId
            }).ToList();

            return model;


            //List<int> status = new List<int>() { 1, 2, 3, 7 };
            //foreach (var line in dbCon.GFI_AMM_VehicleMaintenance
            //     .Where(p => p.MaintTypeId_cbo.ToString().Contains(status.ToString()))
            //        .GroupBy(info => info.MaintTypeId_cbo)
            //            .Select(group => new
            //            {
            //                Metric = group.Key,
            //                Count = group.Count()
            //            }))
            //{
            //    Console.WriteLine("{0} {1}", line.Metric, line.Count);
            //}
            //return new MaintenanceByStatusDto();
        }
    }
}
