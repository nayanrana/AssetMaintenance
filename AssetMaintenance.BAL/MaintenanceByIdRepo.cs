﻿using AssetMaintenance.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using AssetMaintenance.DAL;
using System.Linq;
using System.Web.Script.Serialization;

namespace AssetMaintenance.BAL
{
    public class MaintenanceByIdRepo
    {
        AssetMaintenanceEntities dbCon = new AssetMaintenanceEntities();
        public List<AssetMaintenanceDetailDto> getAssetMaintenanceDetail(int id, int maintId)
        {
            var result = dbCon.GFI_AMM_VehicleMaintenance.Where(c => c.AssetId == id && c.MaintTypeId_cbo == maintId).OrderByDescending(c => c.URI).Take(5).Select(c => new AssetMaintenanceDetailDto
            {
                URI = c.URI,
                Asset = dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == c.AssetId).AssetName,
                Maintenance = dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d => d.MaintTypeId == c.MaintTypeId_cbo).Description,
                ActualOdometer = c.ActualOdometer,
                ActualEngineHrs = c.ActualEngineHrs,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                Amount = c.TotalCost,
                ///AssetNo= dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == c.AssetId).AssetNumber,
                //Reminder= (DateTime)dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d=> d.MaintTypeId == c.MaintStatusId_cbo).OccurrenceFixedDate,
                //NextMaintenance=(DateTime)c.StartDate,
                ///Category= dbCon.GFI_AMM_VehicleMaintCat.FirstOrDefault(d=> d.MaintCatId == dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(s=> s.MaintTypeId==c.MaintTypeId_cbo).MaintCatId_cbo).Description
            }).ToList();

            return result;
        }

        public AssetMaintenanceDetailDto getAssetMaintenanceDetailbyID(int id, int maintId)
        {
            var result = dbCon.GFI_AMM_VehicleMaintenance.Where(c => c.URI == id).OrderByDescending(c => c.URI).Take(1).Select(c => new AssetMaintenanceDetailDto
            {
                URI = c.URI,
                AssetId = c.AssetId,
                Asset = dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == c.AssetId).AssetName,
                Maintenance = dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d => d.MaintTypeId == c.MaintTypeId_cbo).Description,
                ActualOdometer = c.ActualOdometer,
                ActualEngineHrs = c.ActualEngineHrs,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                Amount = c.TotalCost,
                AssetNo = dbCon.GFI_FLT_Asset.FirstOrDefault(d => d.AssetID == c.AssetId).AssetNumber,
                Reminder = (DateTime)dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(d => d.MaintTypeId == c.MaintStatusId_cbo).OccurrenceFixedDate,
                NextMaintenance = (DateTime)c.StartDate,
                Category = dbCon.GFI_AMM_VehicleMaintCat.FirstOrDefault(d => d.MaintCatId == dbCon.GFI_AMM_VehicleMaintTypes.FirstOrDefault(s => s.MaintTypeId == c.MaintTypeId_cbo).MaintCatId_cbo).Description,
                ContactDetails = c.ContactDetails,
                CompanyName = c.CompanyName,
                PhoneNumber = c.PhoneNumber,
                CompanyRef = c.CompanyRef,
                MaintStatusId_cbo = c.MaintStatusId_cbo,
                AssetStatus = c.AssetStatus,
                CalculatedEngineHrs = c.CalculatedEngineHrs,
                CalculatedOdometer = c.CalculatedOdometer,
                Comment = c.Comment,
                CompanyRef2 = c.CompanyRef2,
                CoverTypeId_cbo = c.CoverTypeId_cbo,
                EstimatedValue = c.EstimatedValue,
                MaintDescription = c.MaintDescription,
                TotalCost = c.TotalCost,
                VATAmount = c.VATAmount,
                VATInclInItemsAmt = c.VATInclInItemsAmt,
                MaintTypeId_cbo = c.MaintTypeId_cbo,
            }).SingleOrDefault();
            if (result != null)
                result.lstParts = dbCon.GFI_AMM_VehicleMaintItems.Where(s => s.MaintURI == result.URI).Select(s => new lstPartDetails {URI=s.URI, ItemCode = s.ItemCode, Description = s.Description, Quantity = s.Quantity, UnitCost = s.UnitCost, MaintURI = s.MaintURI }).ToList();
            else
                result = new AssetMaintenanceDetailDto();
            return result;
        }

        public string insertMaintenance(AssetMaintenanceDetailDto assetMaintenance)
        {
            try
            {


                //JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                //var json_serializer = new JavaScriptSerializer();
                //List<lstPartDetails> routes_list = json_serializer.Deserialize<List<lstPartDetails>>(assetMaintenance.Parts);

                GFI_AMM_VehicleMaintenance maint = dbCon.GFI_AMM_VehicleMaintenance.SingleOrDefault(c => c.URI == assetMaintenance.URI);///new GFI_AMM_VehicleMaintenance();
                maint.ActualEngineHrs = assetMaintenance.ActualEngineHrs;
                maint.ActualOdometer = assetMaintenance.ActualOdometer;
                maint.AdditionalInfo = assetMaintenance.AdditionalInfo == "undefined" ? null : assetMaintenance.AdditionalInfo;
                maint.AssetId = assetMaintenance.AssetId;
                maint.AssetStatus = assetMaintenance.AssetStatus;
                maint.CalculatedEngineHrs = assetMaintenance.CalculatedEngineHrs;
                maint.CalculatedOdometer = assetMaintenance.CalculatedOdometer;
                maint.Comment = assetMaintenance.Comment;
                maint.CompanyName = assetMaintenance.CompanyName;
                maint.CompanyRef = assetMaintenance.CompanyRef;
                maint.ContactDetails = assetMaintenance.ContactDetails;
                maint.CoverTypeId_cbo = assetMaintenance.CoverTypeId_cbo;
                maint.EndDate = assetMaintenance.EndDate;
                maint.EstimatedValue = assetMaintenance.EstimatedValue;
                maint.MaintDescription = assetMaintenance.MaintDescription;
                maint.MaintStatusId_cbo = assetMaintenance.MaintStatusId_cbo;
                maint.MaintTypeId_cbo = assetMaintenance.MaintTypeId_cbo;
                maint.PhoneNumber = assetMaintenance.PhoneNumber;
                maint.StartDate = assetMaintenance.StartDate;
                maint.TotalCost = assetMaintenance.TotalCost;
                maint.VATAmount = assetMaintenance.VATAmount;
                maint.VATInclInItemsAmt = assetMaintenance.VATInclInItemsAmt == "undefined" ? null : assetMaintenance.VATInclInItemsAmt;
                maint.CreatedDate = DateTime.Now;
                maint.UpdatedDate = DateTime.Now;
                ///var mainten= dbCon.GFI_AMM_VehicleMaintenance.Add(maint);
                dbCon.SaveChanges();
                dbCon.GFI_AMM_VehicleMaintItems.RemoveRange(dbCon.GFI_AMM_VehicleMaintItems.Where(x => x.MaintURI == maint.URI).ToList());
                foreach (var item in assetMaintenance.lstParts)
                //for (int i = 0; i < length; i++)            
                {
                    GFI_AMM_VehicleMaintItems mainItems = new GFI_AMM_VehicleMaintItems();
                    mainItems.CreatedDate = DateTime.Now;
                    mainItems.Description = item.Description;
                    mainItems.ItemCode = item.ItemCode;
                    mainItems.MaintURI = maint.URI;
                    mainItems.Quantity = item.Quantity;
                    mainItems.UnitCost = item.UnitCost;
                    mainItems.UpdatedDate = item.UpdatedDate;

                    dbCon.GFI_AMM_VehicleMaintItems.Add(mainItems);
                    dbCon.SaveChanges();
                }

                return maint.URI.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
