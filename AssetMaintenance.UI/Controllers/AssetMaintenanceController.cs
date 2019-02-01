using AssetMaintenance.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetMaintenance.UI.Controllers
{
    public class AssetMaintenanceController : Controller
    {
        AssetMaintenanceRepo obj = new AssetMaintenanceRepo();

        // GET: AssestMaintenance
        public ActionResult Index()
        {
            ViewBag.Asset = obj.GetAssestDetails();
            ViewBag.MaintenanceType = obj.GetMaintenanceDetails();
            return View();
        }

        [HttpPost]
        public ActionResult SaveAssestMaintenceType(int assetId,int maintenaceId)
        {
           var result= obj.SaveAssetMaintenance(assetId, maintenaceId);
            if (result == true)
                return Json(new { msg = "Maintenance type successfully assigned to this asset.", type = "success" }, JsonRequestBehavior.AllowGet);
            else if (result == null)
                return Json(new { msg = "Maintenance type is already assigned to this asset.", type = "Error" }, JsonRequestBehavior.AllowGet);
            else
                return Json("");
        }

        [HttpPost]
        public ActionResult GetMaintenanceTypeDetailsById(int maintenanceTypeId)
        {            
            return Json(obj.GetMaintenanceTypeDetailsById(maintenanceTypeId));
        }

        [HttpGet]
        public ActionResult GetAssetAndMaintenanceTypeDetailsByAssetId(int assetId)
        {
            return Json(obj.GetAssetAndMaintenanceTypeDetailsByAssetId(assetId),JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteAssertMaintenanceByID(int id)
        {
            AssetMaintenanceRepo assetmaintenance = new AssetMaintenanceRepo();
            var model = assetmaintenance.deleteAssertMaintenance(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}