using AssetMaintenance.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetMaintenance.BAL
{
    public class MaintenanceByStatusListRepo
    {
        public List<MaintenanceByStatusListDto> getMaintenanceByStatusList(string maintenanceStatus)
        {
            // Will query Database once we have structure ready

            var result = new List<MaintenanceByStatusListDto> {
                new MaintenanceByStatusListDto {
                    AssetNo ="372 JN 102",
                    Asset="Car",
                    Maintenance ="Insurance",
                    NextMaintenance =DateTime.Now.AddDays(10),
                    Reminder =DateTime.Now.AddDays(2)
                },
                 new MaintenanceByStatusListDto {
                    AssetNo ="555 JN 102",
                    Asset="Transformer",
                    Maintenance ="Servicing",
                    NextMaintenance =DateTime.Now.AddDays(100),
                    Reminder =DateTime.Now.AddDays(20)
                },
                  new MaintenanceByStatusListDto {
                    AssetNo ="372 JN 102",
                    Asset="Lorry",
                    Maintenance ="Servicing",
                    NextMaintenance =DateTime.Now.AddDays(50),
                    Reminder =DateTime.Now.AddDays(30)
                }

            };
            return result;
        }

    }
}
