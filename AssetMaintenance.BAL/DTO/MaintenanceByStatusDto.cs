
namespace AssetMaintenance.BAL.DTO
{
    public class MaintenanceByStatusDto
    {
        public int Completed { get; set; }
        public int ToSchedule { get; set; }
        public int OverDue { get; set; }
        public int Scheduled { get; set; }
    }
}
