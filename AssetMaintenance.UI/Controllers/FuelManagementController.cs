using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using AssetMaintenance.BAL;
using AssetMaintenance.BAL.DTO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

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
        public ActionResult CreateFuelRecord(FuelRecordDto fuel)
        {
            var obj = new FuelRecordRepo();
            var statusLst = obj.InsertFuelRecord(fuel);
            return Json("Record saved successfully.");
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
            if(Path.GetExtension(Request.Files[0].FileName)==".xlsx")
            {
                string str = GetDataTableFromSpreadsheet(Request.Files[0].InputStream);

                return Content(str);

            }
            else
            {
                return Content("Please upload Excel Files only");
            }
        }


        public string GetDataTableFromSpreadsheet(Stream MyExcelStream)
        {
            StringBuilder strBuilder = new StringBuilder();
            using (SpreadsheetDocument sDoc = SpreadsheetDocument.Open(MyExcelStream, false))
            {
                WorkbookPart workbookPart = sDoc.WorkbookPart;
                IEnumerable<Sheet> sheets = sDoc.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                string relationshipId = sheets.First().Id.Value;
                WorksheetPart worksheetPart = (WorksheetPart)sDoc.WorkbookPart.GetPartById(relationshipId);
                Worksheet workSheet = worksheetPart.Worksheet;
                SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                IEnumerable<Row> rows = sheetData.Descendants<Row>();

                strBuilder.Append("<thead><tr>");
                foreach (Cell cell in rows.ElementAt(0))
                {
                    strBuilder.Append("<th>" + GetCellValue(sDoc, cell) + "</th>");
                }
                strBuilder.Append("</thead></tr><tbody>");

                foreach (Row row in rows) //this will also include your header row...
                {
                    if (row.RowIndex != 1)
                    {
                        strBuilder.Append("<tr>");

                        for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                        {
                            strBuilder.Append("<td>" + GetCellValue(sDoc, row.Descendants<Cell>().ElementAt(i)) + "</td>");
                        }
                        strBuilder.Append("</tr>");
                    }
                }
                strBuilder.Append("</tbody>");
            }
            return strBuilder.ToString();

        }

        public static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            string value = cell.CellValue.InnerXml;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }

    }
}
