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
        FuelPriceMasterRepo objFuelPriceRepo = new FuelPriceMasterRepo();
        // GET: FuelPricingMaster
        public ActionResult FuelMaster()
        {
            FuelMasterViewModelDto objFuel = new FuelMasterViewModelDto();
            objFuel.FuelList = objFuelPriceRepo.GetFuelDetail();
            objFuel.DieselList = objFuelPriceRepo.GetDisellDetail();
            objFuel.GasoloneList = objFuelPriceRepo.GetGasolineDetail();
            ViewBag.Supplier = objFuelPriceRepo.GetSupplierName();
            return View(objFuel);
        }

        [HttpPost]
        public ActionResult AddFuelMaster(FuelMasterDto objModel)
        {
            if (objModel.Type == "Fuel")
            {
                bool isResult = objFuelPriceRepo.InsertFuelRecord(objModel);
                if (!isResult)
                    return PartialView("");
                var FuelList = objFuelPriceRepo.GetFuelDetail();
                return PartialView("_FuelDetails", FuelList);
            }
            else if(objModel.Type == "Diesel")
            {
                bool isResult = objFuelPriceRepo.InsertDiselRecord(objModel);
                if (!isResult)
                    return PartialView("");
                var FuelList = objFuelPriceRepo.GetDisellDetail();
                return PartialView("_DieselDetails", FuelList);
            }
            else
            {
                bool isResult = objFuelPriceRepo.InsertGasolineRecord(objModel);
                if (!isResult)
                    return PartialView("");
                var FuelList = objFuelPriceRepo.GetGasolineDetail();
                return PartialView("_GasolineDetails", FuelList);
            }
        }
    }
}