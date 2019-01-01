using System;
using System.Collections.Generic;
using System.Text;

namespace AssetMaintenance.BAL.DTO
{
    public class MaintenanceByStatusListDto
    {
        public int URI { get; set; }
        public int AssetID { get; set; }
        public string Asset { get; set; }
        public string AssetNo { get; set; }
        public string Maintenance { get; set; }
        public string MaintenanceStatus { get; set; }
        public int? MaintenanceID { get; set; }
        public DateTime? Reminder { get; set; }
        public DateTime? NextMaintenance { get; set; } 
    }
}
