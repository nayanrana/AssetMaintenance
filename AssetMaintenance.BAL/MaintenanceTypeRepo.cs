using AssetMaintenance.BAL.DTO;
using AssetMaintenance.DAL;
using System.Linq;

namespace AssetMaintenance.BAL
{
    public class MaintenanceTypeRepo
    {
        AssetMaintenanceEntities dbCon;
        CategoriesRepo categoryRepo = new CategoriesRepo();

        public MaintenanceTypeRepo()
        {
            dbCon = new AssetMaintenanceEntities();
        }

        public MaintenanceTypeDto getMaintenanceTypeList(int maintenanceType)
        {
            var maintenanceResult = dbCon.GFI_AMM_VehicleMaintTypes.ToList().Where(x => x.MaintTypeId == maintenanceType).Select(x => new MaintenanceTypeDto
            {
                CategoryId = x.MaintCatId_cbo ?? 0,
                Description = x.Description,
                EngineHrsBasedMaintenanceDue = x.OccurrenceEngineHrs ?? 0,
                EngineHrsBasedAlertThreshold = x.OccurrenceEngineHrsTh ?? 0,
                KMBasedMaintenanceDue = x.OccurrenceKM ?? 0,
                KMBasedAlertThreshold = x.OccurrenceKMTh ?? 0,
                TimeBasedMaintenanceDue = x.OccurrenceDuration ?? 0,
                TimeBasedAlertThreshold = x.OccurrenceDurationTh ?? 0,
                CategoryList = categoryRepo.getAllCategories()
            }).FirstOrDefault();

            return maintenanceResult;
        }

        public string insertMaintenanceType(MaintenanceTypeDto maintenanceType)
        {
            GFI_AMM_VehicleMaintTypes maintType = new GFI_AMM_VehicleMaintTypes();
            maintType.MaintCatId_cbo = maintenanceType.CategoryId;
            maintType.Description = maintenanceType.Description;
            maintType.OccurrenceEngineHrsTh = maintenanceType.EngineHrsBasedAlertThreshold;
            maintType.OccurrenceEngineHrs = maintenanceType.EngineHrsBasedMaintenanceDue;
            maintType.OccurrenceDuration = maintenanceType.OccurrenceDuration;
            maintType.OccurrenceDurationTh = maintenanceType.TimeBasedAlertThreshold;
            maintType.OccurrenceFixedDate = maintenanceType.OccurenceFixedDate;
            maintType.OccurrenceFixedDateTh = maintenanceType.OccurenceFixedDateThreshold;
            maintType.OccurrenceKM = maintenanceType.KMBasedMaintenanceDue;
            maintType.OccurrenceKMTh = maintenanceType.KMBasedAlertThreshold;
            maintType.OccurrencePeriod_cbo = maintenanceType.TimeBasedPeriod;
            maintType.OccurrenceType = maintenanceType.IsFixedDateChecked==true?1:0;
            maintType.UpdatedDate = System.DateTime.Now;
            dbCon.GFI_AMM_VehicleMaintTypes.Add(maintType);
            dbCon.SaveChanges();
            return "";
        }
    }
}
