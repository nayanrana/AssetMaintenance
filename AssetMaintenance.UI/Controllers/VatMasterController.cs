using AssetMaintenance.BAL;
using AssetMaintenance.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetMaintenance.UI.Controllers
{
    public class VatMasterController : Controller
    {
        // GET: VatMaster
        public ActionResult Index(int vatid = 0)
        {
            VatMasterRepo obj = new VatMasterRepo();
            var model = obj.getVatDetailsById(vatid);
            return View(model);
        }

        public ActionResult VatList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateVatMaster(VatMasterDto model)
        {
            var obj = new VatMasterRepo();
            int statusLst = 0;

            if (model.VatId > 0)
            {
                if (obj.updatevatdetail(model))
                {
                    statusLst = model.VatId;
                }
            }
            else
            {
                statusLst = obj.insertVatMaster(model);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ViewVatList()
        {
            var obj = new VatMasterRepo();
            List<VatMasterDto> model = obj.getAllVatRecords();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeletevatMasterByID(int id)
        {
            VatMasterRepo vatbyid = new VatMasterRepo();
            var model = vatbyid.deleteVatDetail(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getVatDetailsById(int vatid)
        {
            VatMasterRepo obj = new VatMasterRepo();
            var model = obj.getVatDetailsById(vatid);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}