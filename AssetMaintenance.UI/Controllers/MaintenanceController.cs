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
            List<MaintenanceByStatusDto> model= obj.getMaintenanceByStatusCount();

            return View(model);
        }

        [HttpGet]
        public ActionResult MaintenanceByStatusList()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult MaintenanceByStatusList(int maintenanceType)
        {
            var obj = new MaintenanceByStatusListRepo();
            List<MaintenanceByStatusListDto> model = obj.getMaintenanceByStatusList(maintenanceType);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public PartialViewResult _ViewMaintanence(int id)
        {
            var obj = new MaintenanceByIdRepo();
            List<AssetMaintenanceDetailDto> model = obj.getAssetMaintenanceDetail(id);
            return PartialView(model);
        }
        [HttpGet]
        public JsonResult ViewMaintanenceList(int id)
        {
            var obj = new MaintenanceByIdRepo();
            List<AssetMaintenanceDetailDto> model = obj.getAssetMaintenanceDetail(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult BindMaintenanceDetail(int id)
        {
            var obj = new MaintenanceByIdRepo();
            List<AssetMaintenanceDetailDto> model = obj.getAssetMaintenanceDetail(id);
            return View(model.FirstOrDefault());
        }
    }
}