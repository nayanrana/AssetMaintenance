using AssetMaintenance.BAL;
using AssetMaintenance.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetMaintenance.UI.Controllers
{
    public class MaintenanceController : Controller
    {
        public ActionResult MaintenanceByStatus()
        {
            var obj = new MaintenanceByStatusRepo();
            MaintenanceByStatusDto model= obj.getMaintenanceByStatusCount();

            return View(model);
        }

        [HttpGet]
        public ActionResult MaintenanceByStatusList()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult MaintenanceByStatusList(string maintenanceType)
        {
            var obj = new MaintenanceByStatusListRepo();
            List<MaintenanceByStatusListDto> model = obj.getMaintenanceByStatusList(maintenanceType);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}