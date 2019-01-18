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
            obj.SaveAssetMaintenance(assetId, maintenaceId);
            return Json("Maintenance type successfully assigned to this asset.");
        }

        [HttpPost]
        public ActionResult GetMaintenanceTypeDetailsById(int maintenanceTypeId)
        {            
            return Json(obj.GetMaintenanceTypeDetailsById(maintenanceTypeId));
        }
    }
}