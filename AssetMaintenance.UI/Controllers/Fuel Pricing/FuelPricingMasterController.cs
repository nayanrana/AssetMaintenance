using AssetMaintenance.BAL;
using AssetMaintenance.BAL.DTO;
using System;
using System.Collections.Generic;
using System.IO;
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
                var FuelList = objFuelPriceRepo.GetFuelDetail(objModel.SupplierId);
                return PartialView("_FuelDetails", FuelList);
            }
            else if(objModel.Type == "Diesel")
            {
                bool isResult = objFuelPriceRepo.InsertDiselRecord(objModel);
                if (!isResult)
                    return PartialView("");
                var FuelList = objFuelPriceRepo.GetDisellDetail(objModel.SupplierId);
                return PartialView("_DieselDetails", FuelList);
            }
            else
            {
                bool isResult = objFuelPriceRepo.InsertGasolineRecord(objModel);
                if (!isResult)
                    return PartialView("");
                var FuelList = objFuelPriceRepo.GetGasolineDetail(objModel.SupplierId);
                return PartialView("_GasolineDetails", FuelList);
            }
        }

        public ActionResult GetFuelBySupplier(int id)
        {
            FuelMasterViewModelDto objFuel = new FuelMasterViewModelDto();
            objFuel.FuelList = objFuelPriceRepo.GetFuelDetail(id);
            objFuel.DieselList = objFuelPriceRepo.GetDisellDetail(id);
            objFuel.GasoloneList = objFuelPriceRepo.GetGasolineDetail(id);

            var fuelList = RenderRazorViewToString(this.ControllerContext, "_FuelDetails", objFuel.FuelList);
            var dieselList = RenderRazorViewToString(this.ControllerContext, "_DieselDetails", objFuel.DieselList);
            var gasolineList = RenderRazorViewToString(this.ControllerContext, "_GasolineDetails", objFuel.GasoloneList);

            return Json(new { fuelMaster=fuelList, dieselMaster=dieselList, gasolineMaster= gasolineList }, JsonRequestBehavior.AllowGet);
        }


        public static string RenderRazorViewToString(ControllerContext controllerContext,    string viewName, object model)
        {
            controllerContext.Controller.ViewData.Model = model;

            using (var stringWriter = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                var viewContext = new ViewContext(controllerContext, viewResult.View, controllerContext.Controller.ViewData, controllerContext.Controller.TempData, stringWriter);
                viewResult.View.Render(viewContext, stringWriter);
                viewResult.ViewEngine.ReleaseView(controllerContext, viewResult.View);
                return stringWriter.GetStringBuilder().ToString();
            }
        }
    }
}