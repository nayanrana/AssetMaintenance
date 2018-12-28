using System;
using System.Collections.Generic;

namespace AssetMaintenance.BAL.DTO
{
    public class MaintenanceTypeDto
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public bool IsFixedDateChecked { get; set; }
        public DateTime? OccurenceFixedDate { get; set; }
        public int OccurrenceDuration { get; set; }
        public int OccurenceFixedDateThreshold { get; set; }
        public bool IsRecurringChecked { get; set; }
        public int TimeBasedMaintenanceDue { get; set; }
        public int TimeBasedAlertThreshold { get; set; }
        public string TimeBasedPeriod { get; set; }
        public int KMBasedMaintenanceDue { get; set; }
        public int KMBasedAlertThreshold { get; set; }
        public int EngineHrsBasedMaintenanceDue { get; set; }
        public int EngineHrsBasedAlertThreshold { get; set; }
        public List<CategoriesDto> CategoryList { get; set; }
    }
}

