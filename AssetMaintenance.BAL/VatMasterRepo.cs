using AssetMaintenance.BAL.DTO;
using AssetMaintenance.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetMaintenance.BAL
{
    public class VatMasterRepo
    {
        AssetMaintenanceEntities dbCon;

        public VatMasterRepo()
        {
            dbCon = new AssetMaintenanceEntities();
        }

        public int insertVatMaster(VatMasterDto vatadd)
        {
            try
            {
                GFI_FLT_VatMaster vat = new GFI_FLT_VatMaster();
                vat.Vat = vatadd.Vat;
                vat.StartDate = vatadd.StartDate.HasValue?vatadd.StartDate.Value : System.DateTime.Now;
                vat.EndDate = vatadd.EndDate.HasValue?vatadd.EndDate.Value : System.DateTime.Now;
                dbCon.GFI_FLT_VatMaster.Add(vat);
                dbCon.SaveChanges();
                return vat.VatId;

            }
            catch (Exception)
            {
                throw;
                return 0;
            }
        }

        public List<VatMasterDto> getAllVatRecords()
        {
            var vatlist = dbCon.GFI_FLT_VatMaster.AsEnumerable().Select(x => new VatMasterDto
            {
                VatId = x.VatId,
                Vat = x.Vat,
                StartDate = x.StartDate,
                EndDate = x.EndDate
            });
            return vatlist.ToList();
        }

        public VatMasterDto getVatDetailsById(int vatid)
        {
            if (vatid > 0)
            {
                var vatResult = dbCon.GFI_FLT_VatMaster.Where(x => x.VatId == vatid).Select(x => new VatMasterDto
                {
                    VatId = x.VatId,
                    Vat = x.Vat,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate
                }).FirstOrDefault();
                return vatResult;
            }
            else
            {
                return new VatMasterDto();
            }
        }

        public bool updatevatdetail(VatMasterDto model)
        {
            try
            {
                var vat = dbCon.GFI_FLT_VatMaster.Where(x => x.VatId == model.VatId).FirstOrDefault();
                vat.Vat = model.Vat;
                vat.StartDate = model.StartDate.HasValue ? model.StartDate.Value : System.DateTime.Now;
                vat.EndDate = model.EndDate.HasValue ? model.EndDate.Value : System.DateTime.Now; 
                dbCon.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public string deleteVatDetail(int id)
        {
            
            GFI_FLT_VatMaster vatmasetr = dbCon.GFI_FLT_VatMaster.SingleOrDefault(c => c.VatId == id);
            dbCon.GFI_FLT_VatMaster.Remove(vatmasetr);
            dbCon.SaveChanges();
            return "Data Deleted successfully.";
        }
    }
}
