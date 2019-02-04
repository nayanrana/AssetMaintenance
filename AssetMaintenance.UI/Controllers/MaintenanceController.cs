﻿using AssetMaintenance.BAL;
using AssetMaintenance.BAL.DTO;
using System;
using System.Collections.Generic;
using System.IO;
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
            List<MaintenanceByStatusDto> model = obj.getMaintenanceByStatusCount();
            //MaintenanceByStatusDto model = obj.getMaintenanceByStatusCount();

            return View(model);
        }

        [HttpGet]
        public ActionResult MaintenanceByStatusList()
        {
            //var statusLst = new MaintenanceByStatusRepo().getMaintenanceByStatusCount().Where(x => x.MaintStatusId == 1 || x.MaintStatusId == 2 || x.MaintStatusId == 3 || x.MaintStatusId == 7).ToList();            
            //statusLst.Insert(0, new MaintenanceByStatusDto() { Description = "-All-", MaintStatusId = 0});
            //ViewBag.Organisations = new SelectList(statusLst, "MaintStatusId", "Description");
            return View();
        }

        [HttpPost]
        public ActionResult MaintenanceByStatusList(int maintenanceType)
        {
            var obj = new MaintenanceByStatusListRepo();
            List<MaintenanceByStatusListDto> model = obj.getMaintenanceByStatusList(maintenanceType);
            //ViewBag.lstStatus = statusLst.Where(x => x.MaintStatusId == 1 || x.MaintStatusId == 2 || x.MaintStatusId == 3 ||x.MaintStatusId == 7);            
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AllMaintenanceByStatusList()
        {
            var statusLst = new MaintenanceByStatusRepo().getMaintenanceByStatusCount().Where(x => x.MaintStatusId == 1 || x.MaintStatusId == 2 || x.MaintStatusId == 3 || x.MaintStatusId == 7 || x.MaintStatusId == 5 || x.MaintStatusId == 6).ToList();
            statusLst.Insert(0, new MaintenanceByStatusDto() { Description = "-All-", MaintStatusId = 0 });
            ViewBag.Organisations = new SelectList(statusLst, "MaintStatusId", "Description");
            return View();
        }

        [HttpPost]
        public ActionResult AllMaintenanceByStatusList(int maintenanceType)
        {
            var obj = new MaintenanceByStatusListRepo();
            List<MaintenanceByStatusListDto> model = obj.getAllMaintenanceByStatusList(maintenanceType);
            //ViewBag.lstStatus = statusLst.Where(x => x.MaintStatusId == 1 || x.MaintStatusId == 2 || x.MaintStatusId == 3 ||x.MaintStatusId == 7);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public PartialViewResult _ViewMaintanence(int id)
        {
            //var obj = new MaintenanceByIdRepo();
            //List<AssetMaintenanceDetailDto> model = obj.getAssetMaintenanceDetail(id);
            return PartialView();
        }
        [HttpGet]
        public JsonResult ViewMaintanenceList(int id, int maintId)
        {
            var obj = new MaintenanceByIdRepo();
            List<AssetMaintenanceDetailDto> model = obj.getAssetMaintenanceDetail(id, maintId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult BindMaintenanceDetail(int id, int mainId, int statusId)
        {
            var obj = new MaintenanceByIdRepo();
            var statusLst = new MaintenanceByStatusRepo().getMaintenanceByStatusCount();

            var schduledAndCompletedStatusId = new int[] { 3, 5 };

            if (statusId == 1 || statusId == 2 || statusId == 5)
            {
                ViewBag.lstStatus = statusLst.Where(x => schduledAndCompletedStatusId.Contains(x.MaintStatusId));
            }
            if (statusId == 3)
            {
                ViewBag.lstStatus = statusLst.Where(x => x.MaintStatusId == 5);
            }
            if (statusId == 7)
            {
                ViewBag.lstStatus = statusLst.Where(x => x.MaintStatusId == 6);
            }

            AssetMaintenanceDetailDto model = obj.getAssetMaintenanceDetailbyID(id, mainId);
            var filePaths = Directory.GetFiles(Server.MapPath("/Uploaded_File"))
                        .Where(f => Path.GetFileNameWithoutExtension(f).ToLower() == model.URI.ToString().ToLower()).Select(f => Path.GetFileName(f));
                        
            if (filePaths.Count() > 0)
                model.FileName = "~/Uploaded_File/" + filePaths.FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public JsonResult InsertMaintenance(AssetMaintenanceDetailDto asstMaint)
        {
            var obj = new MaintenanceByIdRepo();
            var statusLst = obj.insertMaintenance(asstMaint);
            if (string.IsNullOrEmpty(statusLst))
                return Json("Error occured. Please try again after some time.");

            if (Request.Files.Count > 0)
            {
                var uploadFiles = Request.Files[0];
                //Save File
                var fileContent = Request.Files[0];
                if (fileContent != null && fileContent.ContentLength > 0)
                {
                    // get a stream
                    var stream = fileContent.InputStream;
                    // and optionally write the file to disk
                    var fileName = statusLst + Path.GetExtension(fileContent.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploaded_File"), fileName);

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }

                    fileContent.SaveAs(path);
                }
            }
            return Json("Record saved successfully.");
        }
    }
}