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
        public List<MaintenanceByStatusDto> getMaintenanceByStatusCount()
        {
            var model = dbCon.GFI_AMM_VehicleMaintStatus.AsEnumerable()
                .Where(c=> c.Description.ToLower()== "completed" || c.Description.ToLower() == "overdue" || c.Description.ToLower() == "scheduled" || c.Description.ToLower() == "to schedule")
            .Select(x => new MaintenanceByStatusDto
            {
                Description =x.Description, ///dbCon.GFI_AMM_VehicleMaintStatus.FirstOrDefault(c => c.MaintStatusId == x.MaintStatusId).Description,
                NoofStatus = dbCon.GFI_AMM_VehicleMaintenance.Where(c => c.MaintStatusId_cbo == x.MaintStatusId).Count(),
                MaintStatusId=x.MaintStatusId
            }).ToList();



            //dbCon.GFI_AMM_VehicleMaintStatus
            //       .GroupBy(p => p.MaintStatusId)
            //       .Select(g => new MaintenanceByStatusDto { Description = dbCon.GFI_AMM_VehicleMaintStatus.FirstOrDefault(c=> c.MaintStatusId== g.Key).Description, MaintStatusId = g.Where(c=>c.MaintStatusId== g.Key).Count() }).ToList();         

            //    new MaintenanceByStatusDto
            //{
            //    Completed = 90,
            //    OverDue = 70,
            //    Scheduled = 50,
            //    ToSchedule = 20
            //};
            return model;
        }
    }
}
