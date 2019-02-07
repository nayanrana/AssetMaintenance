using AssetMaintenance.BAL.DTO;
using AssetMaintenance.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMaintenance.BAL
{
    public class FuelRecordRepo
    {
        AssetMaintenanceEntities dbCon;

        public FuelRecordRepo()
        {
            dbCon = new AssetMaintenanceEntities();
        }

        public List<FuelRecordDto> getAllFuelRecords()
        {
            var fuelList = dbCon.Fuel_Record.AsEnumerable().Select(x => new FuelRecordDto
            {
                Id = x.Id,
                FillingStation = x.FillingStation,
                SupplierCode = x.SupplierCode,
                SupplierName = x.SupplierName,
                ClaimNumber = x.ClaimNumber,
                InvoiceNo = x.InvoiceNo,
                InvoiceDate = x.InvoiceDate,
                PaymentCertNo = x.PaymentCertNo,
                Period = x.Period,
                DiscountAmountDiesel = x.DiscountAmountDiesel,
                DiscountAmountGasoline = x.DiscountAmountGasoline,
                InvoiceDiscountAmount = x.InvoiceDiscountAmount,
                RegistrationNo = x.RegistrationNo,
                InvoiceTotalAmount = x.InvoiceTotalAmount,
                InvoiceVatAmount = x.InvoiceVatAmount,
                AmountDieselLt = x.AmountDieselLt,
                AmountGasolineLt = x.AmountGasolineLt,
                Is_PaymentReceiptGenerate = x.Is_PaymentReceiptGenerate
            });
            return fuelList.ToList();
        }

        public int InsertFuelRecord(FuelRecordDto fuel)
        {
            try
            {
                Fuel_Record ful = new Fuel_Record();
                ful.FillingStation = fuel.FillingStation;
                ful.SupplierCode = fuel.SupplierCode;
                ful.SupplierName = fuel.SupplierName;
                ful.ClaimNumber = fuel.ClaimNumber;
                ful.InvoiceNo = fuel.InvoiceNo;
                ful.InvoiceDate = fuel.InvoiceDate;
                ful.PaymentCertNo = fuel.PaymentCertNo;
                ful.Period = fuel.Period;
                ful.DiscountAmountDiesel = fuel.DiscountAmountDiesel;
                ful.DiscountAmountGasoline = fuel.DiscountAmountGasoline;
                ful.InvoiceDiscountAmount = fuel.InvoiceDiscountAmount;
                ful.RegistrationNo = fuel.RegistrationNo;
                ful.InvoiceTotalAmount = fuel.InvoiceTotalAmount;
                ful.InvoiceVatAmount = fuel.InvoiceVatAmount;
                ful.AmountDieselLt = fuel.AmountDieselLt;
                ful.AmountGasolineLt = fuel.AmountGasolineLt;
                ful.Is_PaymentReceiptGenerate = fuel.Is_PaymentReceiptGenerate;
                ful.Is_Excel = fuel.Modeofupload == 0 ? true : false;

                dbCon.Fuel_Record.Add(ful);
                dbCon.SaveChanges();
                return ful.Id;

            }
            catch (Exception)
            {
                throw;
                return 0;
            }
        }

        public FuelRecordDto getFuelManagerByID(int fuelmanagetid)
        {
            if (fuelmanagetid > 0)
            {
                var fuelmanagerResult = dbCon.Fuel_Record.Where(x => x.Id == fuelmanagetid).Select(x => new FuelRecordDto
                {

                    Id = x.Id,
                    FillingStation = x.FillingStation,
                    SupplierCode = x.SupplierCode,
                    SupplierName = x.SupplierName,
                    ClaimNumber = x.ClaimNumber,
                    InvoiceNo = x.InvoiceNo,
                    InvoiceDate = x.InvoiceDate,
                    PaymentCertNo = x.PaymentCertNo,
                    Period = x.Period,
                    DiscountAmountDiesel = x.DiscountAmountDiesel,
                    DiscountAmountGasoline = x.DiscountAmountGasoline,
                    InvoiceDiscountAmount = x.InvoiceDiscountAmount,
                    RegistrationNo = x.RegistrationNo,
                    InvoiceTotalAmount = x.InvoiceTotalAmount,
                    InvoiceVatAmount = x.InvoiceVatAmount,
                    AmountDieselLt = x.AmountDieselLt,
                    AmountGasolineLt = x.AmountGasolineLt,
                    Is_PaymentReceiptGenerate = x.Is_PaymentReceiptGenerate

                }).FirstOrDefault();
                return fuelmanagerResult;
            }
            else
            {

                return new FuelRecordDto();
            }


        }

        public bool updateFuelRecord(FuelRecordDto fuel)
        {
            try
            {
                var ful = dbCon.Fuel_Record.Where(x => x.Id == fuel.Id).FirstOrDefault();
                ful.FillingStation = fuel.FillingStation;
                ful.SupplierCode = fuel.SupplierCode;
                ful.SupplierName = fuel.SupplierName;
                ful.ClaimNumber = fuel.ClaimNumber;
                ful.InvoiceNo = fuel.InvoiceNo;
                ful.InvoiceDate = fuel.InvoiceDate;
                ful.PaymentCertNo = fuel.PaymentCertNo;
                ful.Period = fuel.Period;
                ful.DiscountAmountDiesel = fuel.DiscountAmountDiesel;
                ful.DiscountAmountGasoline = fuel.DiscountAmountGasoline;
                ful.InvoiceDiscountAmount = fuel.InvoiceDiscountAmount;
                ful.RegistrationNo = fuel.RegistrationNo;
                ful.InvoiceTotalAmount = fuel.InvoiceTotalAmount;
                ful.InvoiceVatAmount = fuel.InvoiceVatAmount;
                ful.AmountDieselLt = fuel.AmountDieselLt;
                ful.AmountGasolineLt = fuel.AmountGasolineLt;
                ful.Is_PaymentReceiptGenerate = fuel.Is_PaymentReceiptGenerate;
                dbCon.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public string deleteFuelManagement(int id)
        {
            dbCon.FuelRecord_Detail.RemoveRange(dbCon.FuelRecord_Detail.Where(k => k.FuelRecordId == id).ToList());
            dbCon.SaveChanges();
            Fuel_Record fuelDelete = dbCon.Fuel_Record.SingleOrDefault(c => c.Id == id);

            dbCon.Fuel_Record.Remove(fuelDelete);
            dbCon.SaveChanges();
            return "Data Deleted successfully.";
        }

        //public bool CheckVoucherNumber(FuelRecordDto fuel)
        //{
        //   //return dbCon.Fuel_Record.Any(x => x.VoucherNumber == fuel.VoucherNumber );
        //}
        public List<KeyValuePair<string, int>> GetSupplierName()
        {
            List<KeyValuePair<string, int>> lstKeyValue = new List<KeyValuePair<string, int>>();

            lstKeyValue = (dbCon.Suppliers.AsEnumerable().Where(x => x.IsFuel == true).Select(x =>
                               new KeyValuePair<string, int>
                               (
                                  x.Name,
                                 x.Id
                               )).ToList());
            return lstKeyValue;
        }

        public List<KeyValuePair<int, string>> GetFillingStation()
        {
            try
            {
                List<KeyValuePair<int, string>> lstKeyValue = new List<KeyValuePair<int, string>>();
                lstKeyValue = (dbCon.GFI_SYS_LookUpValues.AsEnumerable().Where(c => c.TID == 2).Select(x =>
                                 new KeyValuePair<int, string>
                                 (
                                    x.TID,
                                     x.Name
                                 )).ToList());
                return lstKeyValue;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<KeyValuePair<int, string>> GetRegistrationNo()
        {
            try
            {
                List<KeyValuePair<int, string>> lstKeyValue = new List<KeyValuePair<int, string>>();
                lstKeyValue = (dbCon.GFI_FLT_Asset.AsEnumerable().Select(x =>
                               new KeyValuePair<int, string>
                               (
                                  x.AssetID,
                                   x.AssetName
                               )).ToList());
                return lstKeyValue;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<KeyValuePair<string, object>> GetDataBySupllier(int id)
        {
            try
            {
                List<KeyValuePair<string, object>> lstkeys = new List<KeyValuePair<string, object>>();

                supllierdetailmodel responce = new supllierdetailmodel();
               
                     responce = dbCon.GFI_FuelDetail.Where(k => k.SupplierId == id).Select(c => new supllierdetailmodel
                     {  Price = c.Price,
                        Discount = c.Discount
                    }).FirstOrDefault();
                lstkeys.Add(new KeyValuePair<string, object>("Petrol", responce));
                      responce = dbCon.GFI_DieselDetail.Where(k => k.SupplierId == id).Select(c => new supllierdetailmodel
                    {
                        Price = c.Price,
                        Discount = c.Discount
                    }).FirstOrDefault();
                lstkeys.Add(new KeyValuePair<string, object>("Diesel", responce));
                responce = dbCon.GFI_GasolineDetail.Where(k => k.SupplierId == id).Select(c => new supllierdetailmodel
                    {
                        Price = c.Price,
                        Discount = c.Discount
                    }).FirstOrDefault();

                lstkeys.Add(new KeyValuePair<string, object>("Gesoline", responce));

                responce = dbCon.Suppliers.Where(k => k.Id == id).Select(c => new supllierdetailmodel
                {

                    Address = c.Address
                    
                   
                }).FirstOrDefault();

                lstkeys.Add(new KeyValuePair<string, object>("Address", responce));

                return lstkeys;
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }

        public double Getvatdetail()
        {
            try
            {
                
                var vatamt = (dbCon.GFI_FLT_VatMaster.Where(vat=>(   System.DateTime.Now > vat.StartDate  && System.DateTime.Now < vat.EndDate)).FirstOrDefault());
                if(vatamt == null)
                {
                   
                    return 15;
                }
                else
                {
                    return vatamt.Vat;
                }
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
        
}
