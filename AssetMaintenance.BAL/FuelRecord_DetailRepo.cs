using AssetMaintenance.BAL.DTO;
using AssetMaintenance.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetMaintenance.BAL
{
    public class FuelRecord_DetailRepo
    {
        AssetMaintenanceEntities dbCon;

        public FuelRecord_DetailRepo()
        {
            dbCon = new AssetMaintenanceEntities();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstFuelRecodDto"></param>
        /// <returns></returns>
        public bool InsertFuelRecordDetail(List<FuelRecord_DetailDto> lstFuelRecodDto, int fuelId)
        {
            try
            {
                FuelRecord_Detail objFuelDetails;
                //dbCon.FuelRecord_Detail.RemoveRange(dbCon.FuelRecord_Detail.Where(k => k.FuelRecordId == fuelId).ToList());
                //dbCon.SaveChanges();

                foreach (var item in lstFuelRecodDto)
                {
                    objFuelDetails = new FuelRecord_Detail();
                    objFuelDetails.FuelRecordId = fuelId;
                    objFuelDetails.ActualMilage = item.ActualMilage;
                    objFuelDetails.AmountExVal = item.AmountExVal;
                    objFuelDetails.AmountInVal = item.AmountInVal.HasValue ? item.AmountInVal.Value : 0;
                    objFuelDetails.CurrentMilage = item.CurrentMilage;
                    objFuelDetails.Date = item.Date;
                    objFuelDetails.Discount = item.Discount;
                    objFuelDetails.Driver = item.Driver;
                    objFuelDetails.FillingStation = item.FillingStation;

                    objFuelDetails.FuelType = item.FuelType;
                    objFuelDetails.Quantities = item.Quantities;
                    objFuelDetails.VatAmount = item.VatAmount;
                    objFuelDetails.VoucherNo = item.VoucherNo;
                    objFuelDetails.PeriodFrom = item.PeriodFrom;
                    objFuelDetails.PeriodTo = item.PeriodTo;
                    objFuelDetails.FuelInvoiceNo = item.FuelInvoiceNo;
                    objFuelDetails.InvoiceDate = item.InvoiceDate;
                    objFuelDetails.PaymentCertificateNo = item.PaymentCertificateNo;
                    objFuelDetails.SupplierCodeName = item.SupplierCodeName;
                    objFuelDetails.DiscountAmountDiesel = item.DiscountAmountDiesel;
                    objFuelDetails.DiscountAmountGasoline = item.DiscountAmountGasoline;
                    objFuelDetails.InvoiceDiscountAmount = item.InvoiceDiscountAmount;
                    objFuelDetails.InvoiceTotalAmount = item.InvoiceTotalAmount;
                    objFuelDetails.FuelType = "1";
                    objFuelDetails.InvoiceVatAmount = item.InvoiceVatAmount;
                    objFuelDetails.AmountDieselLt = item.AmountDieselLt;
                    objFuelDetails.AmountGasolineLt = item.AmountGasolineLt;
                    objFuelDetails.ClaimNo = item.ClaimNo;

                    objFuelDetails.RegistrationNo = string.IsNullOrEmpty(item.RegistrationNo) ? string.Empty : item.RegistrationNo;
                    dbCon.FuelRecord_Detail.Add(objFuelDetails);
                }
                dbCon.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<FuelRecord_DetailDto> getFuelDetails(int fuelid)
        {
            var fueldetails = dbCon.FuelRecord_Detail.Where(k => k.FuelRecordId == fuelid).Select(k => new FuelRecord_DetailDto
            {
                AmountExVal = k.AmountExVal,
                AmountInVal = k.AmountInVal,
                Date = k.Date,
                Discount = k.Discount,
                FillingStation = k.FillingStation,
                FuelType = k.FuelType,
                Quantities = k.Quantities,
                VatAmount = k.VatAmount,
                VoucherNo = k.VoucherNo,
                FuelRecord_DetailId = k.FuelRecord_DetailId,
                RegistrationNo = k.RegistrationNo,
                ActualMilage = k.ActualMilage,
                FuelRecordId = k.FuelRecordId,
                CurrentMilage = k.CurrentMilage,
                PeriodFrom = k.PeriodFrom,
                PeriodTo = k.PeriodTo,
                FuelInvoiceNo = k.FuelInvoiceNo,
                InvoiceDate=k.InvoiceDate,
                PaymentCertificateNo = k.PaymentCertificateNo,
                SupplierCodeName = k.SupplierCodeName,
                DiscountAmountDiesel = k.DiscountAmountDiesel,
                DiscountAmountGasoline = k.DiscountAmountGasoline,
                InvoiceDiscountAmount = k.InvoiceDiscountAmount,
                InvoiceTotalAmount = k.InvoiceTotalAmount,
                InvoiceVatAmount = k.InvoiceVatAmount,
                AmountDieselLt = k.AmountDieselLt,
                AmountGasolineLt = k.AmountGasolineLt,
                ClaimNo = k.ClaimNo,

                Driver = k.Driver
            }).ToList();

            return fueldetails;
        }

        public FuelRecord_DetailDto getFuelDetailsByid(Int64 fuleldetailid)
        {
            var fueldetails = dbCon.FuelRecord_Detail.Where(k => k.FuelRecord_DetailId == fuleldetailid).Select(k => new FuelRecord_DetailDto
            {

                AmountExVal = k.AmountExVal,
                AmountInVal = k.AmountInVal,
                Date = k.Date,
                Discount = k.Discount,
                FillingStation = k.FillingStation,
                FuelType = k.FuelType,
                Quantities = k.Quantities,
                VatAmount = k.VatAmount,
                VoucherNo = k.VoucherNo,
                FuelRecord_DetailId = k.FuelRecord_DetailId,
                RegistrationNo = k.RegistrationNo,
                ActualMilage = k.ActualMilage,
                FuelRecordId = k.FuelRecordId,
                CurrentMilage = k.CurrentMilage,
                PeriodFrom = k.PeriodFrom,
                PeriodTo = k.PeriodTo,
                FuelInvoiceNo = k.FuelInvoiceNo,
                InvoiceDate = k.InvoiceDate,
                PaymentCertificateNo = k.PaymentCertificateNo,
                SupplierCodeName = k.SupplierCodeName,
                DiscountAmountDiesel = k.DiscountAmountDiesel,
                DiscountAmountGasoline = k.DiscountAmountGasoline,
                InvoiceDiscountAmount = k.InvoiceDiscountAmount,
                InvoiceTotalAmount = k.InvoiceTotalAmount,
                InvoiceVatAmount = k.InvoiceVatAmount,
                AmountDieselLt = k.AmountDieselLt,
                AmountGasolineLt = k.AmountGasolineLt,
                ClaimNo = k.ClaimNo,
                Driver = k.Driver


            }).FirstOrDefault();

            return fueldetails;

        }

        public bool updateFuelRecordManual(FuelRecord_DetailDto fuelmanual)
        {
            try
            {
                var fuelmanagerResult = dbCon.FuelRecord_Detail.Where(x => x.FuelRecord_DetailId == fuelmanual.FuelRecord_DetailId).FirstOrDefault();
                fuelmanagerResult.FillingStation = fuelmanual.FillingStation;
                fuelmanagerResult.Driver = fuelmanual.Driver;
                fuelmanagerResult.ActualMilage = fuelmanual.ActualMilage;
                fuelmanagerResult.CurrentMilage = fuelmanual.CurrentMilage;
                fuelmanagerResult.RegistrationNo = string.IsNullOrEmpty(fuelmanual.RegistrationNo) ? string.Empty : fuelmanual.RegistrationNo;

                fuelmanagerResult.AmountExVal = fuelmanual.AmountExVal;
                fuelmanagerResult.AmountInVal = fuelmanual.AmountInVal.HasValue ? fuelmanual.AmountInVal.Value : 0;
                fuelmanagerResult.Date = fuelmanual.Date;
                fuelmanagerResult.Discount = fuelmanual.Discount;
                fuelmanagerResult.FuelType = fuelmanual.FuelType;
                fuelmanagerResult.Quantities = fuelmanual.Quantities;
                fuelmanagerResult.VatAmount = fuelmanual.VatAmount;
                fuelmanagerResult.VoucherNo = fuelmanual.VoucherNo;

                fuelmanagerResult.PeriodFrom = fuelmanual.PeriodFrom;
                fuelmanagerResult.PeriodTo = fuelmanual.PeriodTo;
                fuelmanagerResult.FuelInvoiceNo = fuelmanual.FuelInvoiceNo;
                fuelmanagerResult.InvoiceDate = fuelmanual.InvoiceDate;
                fuelmanagerResult.PaymentCertificateNo = fuelmanual.PaymentCertificateNo;
                fuelmanagerResult.SupplierCodeName = fuelmanual.SupplierCodeName;
                fuelmanagerResult.DiscountAmountDiesel = fuelmanual.DiscountAmountDiesel;
                fuelmanagerResult.DiscountAmountGasoline = fuelmanual.DiscountAmountGasoline;
                fuelmanagerResult.InvoiceDiscountAmount = fuelmanual.InvoiceDiscountAmount;
                fuelmanagerResult.InvoiceTotalAmount = fuelmanual.InvoiceTotalAmount;
                fuelmanagerResult.InvoiceVatAmount = fuelmanual.InvoiceVatAmount;
                fuelmanagerResult.AmountDieselLt = fuelmanual.AmountDieselLt;
                fuelmanagerResult.AmountGasolineLt = fuelmanual.AmountGasolineLt;
                fuelmanagerResult.ClaimNo = fuelmanual.ClaimNo;

                dbCon.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public object deleteFuelRecord(int id)
        {
            FuelRecord_Detail fuelDelete = dbCon.FuelRecord_Detail.SingleOrDefault(c => c.FuelRecord_DetailId == id);
            dbCon.FuelRecord_Detail.Remove(fuelDelete);
            dbCon.SaveChanges();
            return "Data Deleted successfully.";
        }
    }
}
