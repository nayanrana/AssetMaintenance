using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using AssetMaintenance.BAL;
using AssetMaintenance.BAL.DTO;
using AssetMaintenance.DAL;
using OfficeOpenXml;

namespace AssetMaintenance.UI.Controllers
{
    public class FuelManagementController : Controller
    {
        public List<FuelRecord_DetailDto> ListFuelRecord = new List<FuelRecord_DetailDto>();
        public List<FuelRecordDto> listFuel = new List<FuelRecordDto>();
        // GET: FuelManagement

        public ActionResult Index(int fuelmanagetid = 0)
        {
            FuelRecordRepo obj = new FuelRecordRepo();
            TempData.Clear();

            var model = obj.getFuelManagerByID(fuelmanagetid);
            model.fuelRecordManualDto = new FuelRecord_DetailDto();
            model.fuelRecordManualDto.DateCreated = DateTime.Now.Date;
            ViewBag.Supplier = obj.GetSupplierName();
            ViewBag.FillingStationName = obj.GetFillingStation();
            ViewBag.RegistrationNoList = obj.GetRegistrationNo();
            ViewBag.vat = obj.Getvatdetail();
            return View(model);
        }
        public ActionResult List()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateFuelRecord(FuelRecordDto fuel)
        {
            var obj = new FuelRecordRepo();
            int statusLst = 0;
           
                if (fuel.Id > 0)
                {
                    if (obj.updateFuelRecord(fuel))
                    {
                        statusLst = fuel.Id;
                    }
                }
                else
                {
                    statusLst = obj.InsertFuelRecord(fuel);
                }

                if (statusLst != 0)
                {

                    FuelRecord_DetailRepo objDetail = new FuelRecord_DetailRepo();
                    bool result = objDetail.InsertFuelRecordDetail((TempData.Peek("lstFuelRecod") as List<FuelRecord_DetailDto>), statusLst);
                    TempData.Remove("lstFuelRecod");

                    return Json("Record saved successfully.");
                }
                else
                {
                    return Json("Something went wrong.");

                }
           
           
        }

        [HttpGet]
        public ActionResult ViewFuelList()
        {
            var obj = new FuelRecordRepo();
            List<FuelRecordDto> model = obj.getAllFuelRecords();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DisplayFileData()
        {
            ListFuelRecord = new List<FuelRecord_DetailDto>();
            Regex decimalRegex = new Regex(@"^[0-9]*(\.[0-9]{1,2})?$");
            int id =Convert.ToInt32(((System.Web.HttpRequestWrapper)Request).Form[0]);
            if (Path.GetExtension(Request.Files[0].FileName) == ".xlsx")
            {
                string validationMsg = string.Empty;
                int chkInt = 0;
                double chkDouble;
                DateTime chkDate;

                using (var package = new ExcelPackage(Request.Files[0].InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;

                    if (noOfRow >= 2)
                    {
                        int rowid = 1;
                        FuelRecordRepo objRecord = new FuelRecordRepo();

                        var fillingStation = objRecord.GetFillingStation();
                        var registationNumber = objRecord.GetRegistrationNo();

                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            if (workSheet.Cells[rowIterator, 1].Value == null
                                && workSheet.Cells[rowIterator, 2].Value == null
                                && workSheet.Cells[rowIterator, 3].Value == null
                                && workSheet.Cells[rowIterator, 4].Value == null
                                && workSheet.Cells[rowIterator, 5].Value == null
                                && workSheet.Cells[rowIterator, 6].Value == null
                                && workSheet.Cells[rowIterator, 7].Value == null
                                && workSheet.Cells[rowIterator, 8].Value == null
                                && workSheet.Cells[rowIterator, 9].Value == null
                                && workSheet.Cells[rowIterator, 10].Value == null
                                && workSheet.Cells[rowIterator, 11].Value == null
                                && workSheet.Cells[rowIterator, 12].Value == null
                                && workSheet.Cells[rowIterator, 13].Value == null
                                && workSheet.Cells[rowIterator, 14].Value == null
                                && workSheet.Cells[rowIterator, 15].Value == null
                                )
                            {
                                continue;
                            }
                            FuelRecord_DetailDto model = new FuelRecord_DetailDto();
                            if (workSheet.Cells[rowIterator, 1].Value != null)
                            {

                                if (DateTime.TryParse(workSheet.Cells[rowIterator, 1].Value.ToString(), out chkDate))
                                {
                                    model.Date = chkDate;
                                }
                                else
                                {
                                    validationMsg = "Invalid Date format in excel sheet.";
                                    break;
                                }

                                if (DateTime.TryParse(workSheet.Cells[rowIterator, 1].Value.ToString(), out chkDate))
                                {
                                    model.Date = chkDate;
                                }
                                else
                                {
                                    validationMsg = "Invalid Date format in excel sheet.";
                                    break;
                                }
                                double d;
                                if (double.TryParse(workSheet.Cells[rowIterator, 1].Value.ToString(), out d))
                                {
                                    model.Date = DateTime.FromOADate(d);
                                    //model.Period = DateTime.FromOADate(d);
                                    //model.PeriodTo = DateTime.FromOADate(d);
                                }
                                else
                                {
                                    model.Date = Convert.ToDateTime(workSheet.Cells[rowIterator, 1].Value);
                                    //model.PeriodFrom = Convert.ToDateTime(workSheet.Cells[rowIterator, 1].Value);
                                    //model.PeriodTo = Convert.ToDateTime(workSheet.Cells[rowIterator, 1].Value);
                                    //model.Date = DateTime.ParseExact(workSheet.Cells[rowIterator, 1].Value.ToString(), @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                }
                            }
                            else
                            {
                                validationMsg = "Date is required in excel sheet";
                                break;
                            }

                            if (workSheet.Cells[rowIterator, 2].Value != null)
                            {

                                if (DateTime.TryParse(workSheet.Cells[rowIterator, 2].Value.ToString(), out chkDate))
                                {
                                    model.DateCreated = chkDate;
                                }
                                else
                                {
                                    validationMsg = "Invalid Created Date format in excel sheet.";
                                    break;
                                }

                                if (DateTime.TryParse(workSheet.Cells[rowIterator, 2].Value.ToString(), out chkDate))
                                {
                                    model.DateCreated = chkDate;
                                }
                                else
                                {
                                    validationMsg = "Invalid Created Date format in excel sheet.";
                                    break;
                                }
                                double d;
                                if (double.TryParse(workSheet.Cells[rowIterator, 2].Value.ToString(), out d))
                                {
                                    model.DateCreated = DateTime.FromOADate(d);
                                   
                                }
                                else
                                {
                                    model.DateCreated = Convert.ToDateTime(workSheet.Cells[rowIterator, 2].Value);
                                   
                                    //model.Date = DateTime.ParseExact(workSheet.Cells[rowIterator, 1].Value.ToString(), @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                }
                            }
                            else
                            {
                                validationMsg = "Created Date is required in excel sheet";
                                break;
                            }

                            if (workSheet.Cells[rowIterator, 3].Value != null)
                            {
                                model.VoucherNumber = Convert.ToString(workSheet.Cells[rowIterator, 3].Value);
                            }
                            else
                            {
                                validationMsg = "Voucher Number is required in excel sheet";
                                break;
                            }

                            if (workSheet.Cells[rowIterator, 4].Value != null)
                            {
                                model.CostCentreLocation = Convert.ToString(workSheet.Cells[rowIterator, 4].Value);
                            }
                            else
                            {
                                validationMsg = "Cost Center Location is required in excel sheet";
                                break;
                            }

                            if (workSheet.Cells[rowIterator, 5].Value != null)
                            {
                                model.RegistrationNo = Convert.ToString(workSheet.Cells[rowIterator, 5].Value);
                                if (!registationNumber.Any(x=>x.Value.Trim().ToLower()==model.RegistrationNo.Trim().ToLower()))
                                {
                                    validationMsg = "Registration No. "+ model.RegistrationNo+" Does not exists in database";

                                    break;
                                }
                                else
                                {
                                    model.RegistrationNo = registationNumber.Where(x => x.Value.Trim().ToLower() == model.RegistrationNo.Trim().ToLower()).FirstOrDefault().Key.ToString();

                                }
                            }
                            else
                            {
                                validationMsg = "Registration No. is required in excel sheet";
                                break;
                            }

                           

                            model.FillingStation = Convert.ToString(workSheet.Cells[rowIterator, 6].Value);

                            if (!string.IsNullOrEmpty(model.FillingStation)&&!fillingStation.Any(x => x.Value.Trim().ToLower() == model.FillingStation.Trim().ToLower()))
                            {
                                validationMsg = "Filling Station " + model.FillingStation + " Does not exists in database";

                                break;
                            }
                            else
                            {
                                model.FillingStation = fillingStation.Where(x => x.Value.Trim().ToLower() == model.FillingStation.Trim().ToLower()).FirstOrDefault().Key.ToString();
                            }
                            model.Driver = Convert.ToString(workSheet.Cells[rowIterator, 7].Value);

                            if (workSheet.Cells[rowIterator, 8].Value != null)
                            {
                                model.FuelType = workSheet.Cells[rowIterator, 8].Value.ToString();
                            }
                            else
                            {
                                validationMsg = "Fuel Type is required in excel sheet";
                                break;
                            }
                            if (workSheet.Cells[rowIterator, 9].Value != null)
                            {
                                if (int.TryParse(workSheet.Cells[rowIterator, 9].Value.ToString(), out chkInt))
                                {
                                    model.QuantityLitres = chkInt;
                                }
                                else
                                {
                                    validationMsg = "Invalid Number format for Quantity Litres in excel sheet.";
                                    break;
                                }
                            }
                            else
                            {
                                validationMsg = "Quantity Litres is required in excel sheet";
                                break;
                            }

                            if (workSheet.Cells[rowIterator, 10].Value != null && int.TryParse(workSheet.Cells[rowIterator, 10].Value.ToString(), out chkInt))
                            {
                                model.ActualMilage = chkInt;
                            }
                            else
                            {
                                validationMsg = "Invalid Number format for Actual Milage in excel sheet.";
                                break;
                            }

                            if (workSheet.Cells[rowIterator, 11].Value != null && int.TryParse(workSheet.Cells[rowIterator, 11].Value.ToString(), out chkInt))
                            {
                                model.CurrentMilage = chkInt;
                            }
                            else
                            {
                                validationMsg = "Invalid Number format for Current Milage in excel sheet.";
                                break;
                            }
                            if (workSheet.Cells[rowIterator, 12].Value != null && double.TryParse(workSheet.Cells[rowIterator, 12].Value.ToString(), out chkDouble) && decimalRegex.IsMatch(workSheet.Cells[rowIterator, 12].Value.ToString()))
                            {
                                model.AmountExVal = chkDouble;
                            }
                            else
                            {
                                validationMsg = "Invalid Number format for Amount (Excl. Vat) in excel sheet.";
                                break;
                            }

                            if (workSheet.Cells[rowIterator, 13].Value != null && int.TryParse(workSheet.Cells[rowIterator, 13].Value.ToString(), out chkInt))
                            {
                                if (chkInt > 100)
                                {
                                    validationMsg = "Discount (%) must be less than 100%";
                                    break;
                                }
                                model.DiscountAmount = chkInt;
                            }
                            else
                            {
                                validationMsg = "Invalid Number format for Discount (%) in excel sheet.";
                                break;
                            }
                            if (workSheet.Cells[rowIterator, 14].Value != null && double.TryParse(workSheet.Cells[rowIterator, 14].Value.ToString(), out chkDouble) && decimalRegex.IsMatch(workSheet.Cells[rowIterator, 14].Value.ToString()))
                            {
                                model.VatAmount = chkDouble;
                            }
                            else
                            {
                                validationMsg = "Invalid Number format for Vat Amount in excel sheet.";
                                break;
                            }
                            if (workSheet.Cells[rowIterator, 15].Value != null && double.TryParse(workSheet.Cells[rowIterator, 15].Value.ToString(), out chkDouble) && decimalRegex.IsMatch(workSheet.Cells[rowIterator, 15].Value.ToString()))
                            {
                                model.AmountInVal = chkDouble;
                            }
                            else
                            {
                                validationMsg = "Invalid Number format for Amount inc. vat (Rs) in excel sheet.";
                                break;
                            }
                            if (id == 0)
                            {
                                model.FuelRecord_DetailId = rowid;
                                rowid++;
                            }
                               
                            ListFuelRecord.Add(model);

                        }
                        if(!string.IsNullOrEmpty(validationMsg))
                        {
                            return Json(new { msg = validationMsg, Html = ListFuelRecord }, JsonRequestBehavior.AllowGet);

                        }
                        if (id > 0)
                        {
                            var obj = new FuelRecord_DetailRepo();

                            obj.InsertFuelRecordDetail(ListFuelRecord,id);
                            ListFuelRecord = obj.getFuelDetails(id);

                            return Json(new { msg = validationMsg, Html = ListFuelRecord }, JsonRequestBehavior.AllowGet);

                        }
                        else
                        {
                            if (TempData.ContainsKey("lstFuelRecod"))
                                ListFuelRecord.AddRange((TempData.Peek("lstFuelRecod") as List<FuelRecord_DetailDto>));

                            TempData["lstFuelRecod"] = ListFuelRecord;
                            TempData.Keep("lstFuelRecod");
                            return Json(new { msg = validationMsg, Html = ListFuelRecord }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                        validationMsg = "Excel File can not bt empty.";
                    return Json(new { msg = "Please upload Excel Files only", Html = ListFuelRecord }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { msg = "Please upload Excel Files only", Html = ListFuelRecord }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        public ActionResult CreateFuelManualRecord(FuelRecord_DetailDto model)
        {
            var obj = new FuelRecord_DetailRepo();

            List<FuelRecord_DetailDto> lstfuelRecordManuals = new List<FuelRecord_DetailDto>();
            if (TempData.ContainsKey("lstFuelRecod"))
                lstfuelRecordManuals = (TempData.Peek("lstFuelRecod") as List<FuelRecord_DetailDto>);
            if (model.FuelRecord_DetailId > 0)
            {
                obj.updateFuelRecordManual(model);
                lstfuelRecordManuals = obj.getFuelDetails(model.FuelRecordId);
                return Json(new { msg = "Record added successfully", Html = lstfuelRecordManuals }, JsonRequestBehavior.AllowGet);

            }
            else if (model.FuelRecordId > 0 && model.FuelRecord_DetailId==0)
            {
                List<FuelRecord_DetailDto> lstNewRecords = new List<FuelRecord_DetailDto>();
                lstNewRecords.Add(model);
                obj.InsertFuelRecordDetail(lstNewRecords, model.FuelRecordId);
                lstfuelRecordManuals = obj.getFuelDetails(model.FuelRecordId);

                return Json(new { msg = "Record added successfully", Html = lstfuelRecordManuals }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                lstfuelRecordManuals.Add(model);
            }
            TempData["lstFuelRecod"] = lstfuelRecordManuals;
            TempData.Keep("lstFuelRecod");
            return Json(new { msg = "Record added successfully", Html = lstfuelRecordManuals }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetFuelDetails(int fuelmanagetid)
        {
            var obj = new FuelRecord_DetailRepo();
            return Json(new { msg = "Record added successfully", Html = obj.getFuelDetails(fuelmanagetid) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteFuelManagementByID(int id)
        {
            FuelRecordRepo fulemanagement = new FuelRecordRepo();
            var model = fulemanagement.deleteFuelManagement(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetFuelManualDetails(int fuelmanagemaualbyid)
        {
            var obj = new FuelRecord_DetailRepo();
            return Json(new { msg = "Record added successfully", Html = obj.getFuelDetailsByid(fuelmanagemaualbyid) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteFuelRecordByID(int id)
        {
            FuelRecord_DetailRepo fuelrecord = new FuelRecord_DetailRepo();
            var model = fuelrecord.deleteFuelRecord(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteExcelTempData (int id)
        {
            List<FuelRecord_DetailDto> lstfuelRecordManuals = new List<FuelRecord_DetailDto>();
            if (TempData.ContainsKey("lstFuelRecod"))
                lstfuelRecordManuals = (TempData.Peek("lstFuelRecod") as List<FuelRecord_DetailDto>);
            if(lstfuelRecordManuals.Count>0)
            {
                lstfuelRecordManuals = lstfuelRecordManuals.Where(d => d.FuelRecord_DetailId != id).ToList();
                TempData["lstFuelRecod"] = lstfuelRecordManuals;
                TempData.Keep("lstFuelRecod");
                return Json(new { msg = "Record added successfully", Html = lstfuelRecordManuals }, JsonRequestBehavior.AllowGet);
            }
            return Json(id, JsonRequestBehavior.AllowGet);
        }



        //[HttpGet]
        //public ActionResult GetFuelResult(FuelRecordDto name)
        //{
           
        //    var obj = new FuelRecordRepo();
 
        //    return Json(new { msg = "Record added successfully", Html = obj.GetDataBySupllier(name) }, JsonRequestBehavior.AllowGet);
        //}
        [HttpGet]
        public ActionResult GetFuelResult(int id )
        {
            var obj = new FuelRecordRepo();

            return Json(new { msg = "Record added successfully", Html = obj.GetDataBySupllier(id) }, JsonRequestBehavior.AllowGet);
        }


    }
}
