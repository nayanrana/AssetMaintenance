using AssetMaintenance.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetMaintenance.BAL.DTO;

namespace AssetMaintenance.UI.Controllers
{
    public class MaintenanceTypeController : Controller
    {
        // GET: MaintenanceType
        public ActionResult Index(int maintenanceType=1)
        {
            MaintenanceTypeRepo maintenanceTypeRepo = new MaintenanceTypeRepo();
            var model = maintenanceTypeRepo.getMaintenanceTypeList(maintenanceType);
           
            return View(model);
        }

        public ActionResult CreateMaintenanceType(MaintenanceTypeDto maintType)
        {
            var maintTypeRepo = new MaintenanceTypeRepo();
            var statusLst = maintTypeRepo.insertMaintenanceType(maintType);
            return Json("Record added successfully.");
        }
    }
}