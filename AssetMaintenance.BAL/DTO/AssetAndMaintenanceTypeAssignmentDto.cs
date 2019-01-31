using System;
using System.Collections.Generic;
using System.Text;

namespace AssetMaintenance.BAL.DTO
{
    public class AssetAndMaintenanceTypeAssignmentDto
    {
        public int AssetId { get; set; }
        public int MaintenanceTypeId { get; set; }
        public string AssetName { get; set; }
        public string MaintenanceTypeName { get; set; }
        public int AssetMaintenanceId { get; set; }
    }
}
