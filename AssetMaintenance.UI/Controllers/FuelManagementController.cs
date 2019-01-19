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
using OfficeOpenXml;

namespace AssetMaintenance.UI.Controllers
{
    public class FuelManagementController : Controller
    {
        public List<FuelRecord_DetailDto> ListFuelRecord = new List<FuelRecord_DetailDto>();
        // GET: FuelManagement
        public ActionResult Index()
        {
            FuelRecordDto obj = new FuelRecordDto();
            return View(obj);
        }

       

        [HttpPost]
        public ActionResult CreateFuelRecord(FuelRecordDto fuel)
        {
            var obj = new FuelRecordRepo();
            var statusLst = obj.InsertFuelRecord(fuel);
            if (statusLst != 0)
            {
                FuelRecord_DetailRepo objDetail = new FuelRecord_DetailRepo();
                bool result = objDetail.InsertFuelRecordDetail((TempData.Peek("lstFuelRecod") as List<FuelRecord_DetailDto>), statusLst);
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
            if (Path.GetExtension(Request.Files[0].FileName) == ".xlsx")
            {
                string validationMsg = string.Empty;
                int chkInt = 0;
                double chkDouble;
                //DateTime chkDate = new DateTime();
                DateTime chkDate;

                using (var package = new ExcelPackage(Request.Files[0].InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;

                    if (noOfRow >= 2)
                    {


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
                                )
                            {
                                continue;
                            }
                            FuelRecord_DetailDto model = new FuelRecord_DetailDto();
                            if (workSheet.Cells[rowIterator, 1].Value != null)
                            {

                                //if (DateTime.TryParse(workSheet.Cells[rowIterator, 1].Value.ToString(), out chkDate))
                                //{
                                //    model.Date = chkDate;
                                //}
                                //else
                                //{
                                //    validationMsg = "Invalid Date format in excel sheet.";
                                //    break;
                                //}

                                //if (DateTime.TryParse(workSheet.Cells[rowIterator, 1].Value.ToString(), out chkDate))
                                //{
                                //    model.Date = chkDate;
                                //}
                                //else
                                //{
                                //    validationMsg = "Invalid Date format in excel sheet.";
                                //    break;
                                //}

                                model.Date = DateTime.ParseExact(workSheet.Cells[rowIterator, 1].Value.ToString(), @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                                //model.Date =Convert.ToDateTime(workSheet.Cells[rowIterator, 1].Value);

                            }
                            else
                            {
                                validationMsg = "Date is required in excel sheet";
                                break;
                            }

                            if (workSheet.Cells[rowIterator, 3].Value != null)
                            {
                                model.RegistrationNo = Convert.ToString(workSheet.Cells[rowIterator, 3].Value);
                            }
                            else
                            {
                                validationMsg = "Registration No. is required in excel sheet";
                                break;
                            }

                            model.VoucherNo = Convert.ToString(workSheet.Cells[rowIterator, 2].Value);

                            model.FillingStation = Convert.ToString(workSheet.Cells[rowIterator, 4].Value);
                            model.Driver = Convert.ToString(workSheet.Cells[rowIterator, 5].Value);

                            if (workSheet.Cells[rowIterator, 6].Value != null)
                            {
                                model.FuelType = workSheet.Cells[rowIterator, 6].Value.ToString();
                            }
                            else
                            {
                                validationMsg = "Fuel Type is required in excel sheet";
                                break;
                            }
                            if (workSheet.Cells[rowIterator, 7].Value != null)
                            {
                                if (int.TryParse(workSheet.Cells[rowIterator, 7].Value.ToString(), out chkInt))
                                {
                                    model.Quantities = chkInt;
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

                            if (workSheet.Cells[rowIterator, 8].Value != null && int.TryParse(workSheet.Cells[rowIterator, 8].Value.ToString(), out chkInt))
                            {
                                model.ActualMilage = chkInt;
                            }
                            else
                            {
                                validationMsg = "Invalid Number format for Actual Milage in excel sheet.";
                                break;
                            }

                            if (workSheet.Cells[rowIterator, 9].Value != null && int.TryParse(workSheet.Cells[rowIterator, 9].Value.ToString(), out chkInt))
                            {
                                model.CurrentMilage = chkInt;
                            }
                            else
                            {
                                validationMsg = "Invalid Number format for Current Milage in excel sheet.";
                                break;
                            }
                            if (workSheet.Cells[rowIterator, 10].Value != null && double.TryParse(workSheet.Cells[rowIterator, 10].Value.ToString(), out chkDouble) && decimalRegex.IsMatch(workSheet.Cells[rowIterator, 10].Value.ToString()))
                            {
                                model.AmountExVal = chkDouble;
                            }
                            else
                            {
                                validationMsg = "Invalid Number format for Amount (Excl. Vat) in excel sheet.";
                                break;
                            }

                            if (workSheet.Cells[rowIterator, 11].Value != null && int.TryParse(workSheet.Cells[rowIterator, 11].Value.ToString(), out chkInt))
                            {
                                if (chkInt > 100)
                                {
                                    validationMsg = "Discount (%) must be less than 100%";
                                    break;
                                }
                                model.Discount = chkInt;
                            }
                            else
                            {
                                validationMsg = "Invalid Number format for Discount (%) in excel sheet.";
                                break;
                            }
                            if (workSheet.Cells[rowIterator, 12].Value != null && double.TryParse(workSheet.Cells[rowIterator, 12].Value.ToString(), out chkDouble) && decimalRegex.IsMatch(workSheet.Cells[rowIterator, 13].Value.ToString()))
                            {
                                model.VatAmount = chkDouble;
                            }
                            else
                            {
                                validationMsg = "Invalid Number format for Vat Amount in excel sheet.";
                                break;
                            }
                            if (workSheet.Cells[rowIterator, 13].Value != null && double.TryParse(workSheet.Cells[rowIterator, 13].Value.ToString(), out chkDouble) && decimalRegex.IsMatch(workSheet.Cells[rowIterator, 13].Value.ToString()))
                            {
                                model.AmountInVal = chkDouble;
                            }
                            else
                            {
                                validationMsg = "Invalid Number format for Amount inc. vat (Rs) in excel sheet.";
                                break;
                            }
                            ListFuelRecord.Add(model);

                        }
                        TempData["lstFuelRecod"] = ListFuelRecord;
                        TempData.Keep("lstFuelRecod");
                        return Json(new { msg = validationMsg, Html = ListFuelRecord }, JsonRequestBehavior.AllowGet);

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

        public bool IsDate(Object obj)
        {

            string strDate = Convert.ToDateTime(obj).ToString();
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[HttpPost]
        //public ActionResult CreateFuelManualRecord()
        //{
        //    ListFuelRecord = new List<FuelRecord_DetailDto>();
        //    string validationMsg = string.Empty;
        //    int chkInt = 0;
        //    double chkDouble = 0;
        //    //DateTime chkDate = new DateTime();
        //    DateTime chkDate;
            
        //        var currentSheet = package.Workbook.Worksheets;
        //        var workSheet = currentSheet.First();
        //        var noOfCol = workSheet.Dimension.End.Column;
        //        var noOfRow = workSheet.Dimension.End.Row;

            
               

        //        FuelRecordManualDto model = new FuelRecordManualDto();
        //        if (model.Date != null)
        //        {
        //            model.Date = DateTime.ParseExact(workSheet.Cells[1].Value.ToString(), @"d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        //        }
        //        else
        //        {
        //            validationMsg = "Date is required in excel sheet";
                    
        //        }
        //        model.VoucherNumber = Convert.ToString(workSheet.Cells[2].Value);
        //        model.Period= Convert.ToString(workSheet.Cells[3].Value);
        //        model.FillingStation = Convert.ToString(workSheet.Cells[4].Value);
        //        model.ClaimNumber = Convert.ToString(workSheet.Cells[ 5].Value);

        //        if (model.FuelType != null)
        //        {
        //            model.FuelType = workSheet.Cells[ 6].Value.ToString();
        //        }
        //        else
        //        {
        //            validationMsg = "Fuel Type is required in excel sheet";
                   
        //        }
        //        model.QuantityLiter = chkInt;
        //        model.Amount = chkDouble;

        //        if (workSheet.Cells[ 11].Value != null && int.TryParse(workSheet.Cells[ 11].Value.ToString(), out chkInt))
        //        {
        //            if (chkInt > 100)
        //            {
        //                validationMsg = "Discount (%) must be less than 100%";
                        
        //            }
        //            model.DiscountAmount = chkInt;
        //        }
        //        else
        //        {
        //            validationMsg = "Invalid Number format for Discount (%) in excel sheet.";
                   
        //        }
        //        if (workSheet.Cells[ 12].Value != null && double.TryParse(workSheet.Cells[ 12].Value.ToString(), out chkDouble) )
        //        {
        //            model.VatAmount = chkDouble;
        //        }
        //        else
        //        {
        //            validationMsg = "Invalid Number format for Vat Amount in excel sheet.";
                   
        //        }

        //        if (workSheet.Cells[ 13].Value != null && double.TryParse(workSheet.Cells[ 13].Value.ToString(), out chkDouble) )
        //        {
        //            model.AmountInc = chkDouble;
        //        }
        //        else
        //        {
        //            validationMsg = "Invalid Number format for Amount inc. vat (Rs) in excel sheet.";
                    
        //        }
        //        ListFuelRecord.Add(model);
        //        TempData["lstFuelRecod"] = ListFuelRecord;
        //        TempData.Keep("lstFuelRecod");
        //        return Json(new { msg = validationMsg, Html = ListFuelRecord }, JsonRequestBehavior.AllowGet);
                

        //    }
        //}
    }
}
