using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetMaintenance.BAL;
using AssetMaintenance.BAL.DTO;

namespace AssetMaintenance.UI.Controllers
{
    public class FuelManagementController : Controller
    {
        // GET: FuelManagement
        public ActionResult Index()
        {
            FuelRecordDto obj = new FuelRecordDto();
            return View(obj);
        }

        [HttpPost]
        public JsonResult CreateFuelRecord(FuelRecordDto fuel)
        {
            var obj = new FuelRecordRepo();
            var statusLst = obj.InsertFuelRecord(fuel);
            return Json("Record saved successfully.");
        }

        [HttpGet]
        public JsonResult ViewFuelList()
        {
            var obj = new FuelRecordRepo();
            List<FuelRecordDto> model = obj.getAllFuelRecords();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}