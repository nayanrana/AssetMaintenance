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
            var model = maintenanceTypeRepo.getMaintenanceTypeByID(maintenanceType);
           
            return View(model);
        }

        public ActionResult CreateMaintenanceType(MaintenanceTypeDto maintType)
        {
            var maintTypeRepo = new MaintenanceTypeRepo();
            var statusLst = maintTypeRepo.insertMaintenanceType(maintType);
            return Json("Record saved successfully.");
        }
         
        public ActionResult BindMaintenanceType()
        { 
            return View( );
        }
        [HttpPost]
        public ActionResult BindMaintenanceTypeList()
        {
            MaintenanceTypeRepo maintenanceTypeRepo = new MaintenanceTypeRepo();
            var model = maintenanceTypeRepo.getMaintenanceTypeList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteMaintenanceTypeByID(int id)
        {
            MaintenanceTypeRepo maintenanceTypeRepo = new MaintenanceTypeRepo();
            var model = maintenanceTypeRepo.deleteMaintType(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}