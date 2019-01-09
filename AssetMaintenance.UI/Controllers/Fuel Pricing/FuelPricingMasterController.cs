using AssetMaintenance.BAL;
using AssetMaintenance.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetMaintenance.UI.Controllers.Fuel_Master
{
    public class FuelPricingMasterController : Controller
    {
        FuelPriceMasterRepo objFuelPriceMasterRepo = new FuelPriceMasterRepo();
        // GET: FuelPricingMaster
        public ActionResult FuelMaster()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFuelMaster(FuelMasterDto objModel)
        {
            objFuelPriceMasterRepo.InsertFuelRecord(objModel);
            return View();
        }
    }
}