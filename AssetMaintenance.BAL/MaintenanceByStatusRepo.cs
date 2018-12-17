using AssetMaintenance.BAL.DTO;
using System;

namespace AssetMaintenance.BAL
{
    public class MaintenanceByStatusRepo
    {
        public MaintenanceByStatusDto getMaintenanceByStatusCount()
        {
            var model = new MaintenanceByStatusDto
            {
                Completed = 90,
                OverDue = 70,
                Scheduled = 50,
                ToSchedule = 20
            };
            return model;
        }
    }
}
