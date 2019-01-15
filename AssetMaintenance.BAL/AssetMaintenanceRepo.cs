using AssetMaintenance.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace AssetMaintenance.BAL
{
    public class AssetMaintenanceRepo
    {
        AssetMaintenanceEntities dbCon = new AssetMaintenanceEntities();

        public List<KeyValuePair<int, string>> GetAssestDetails()
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


        public List<KeyValuePair<int, string>> GetMaintenanceDetails()
        {
            try
            {
                List<KeyValuePair<int, string>> lstKeyValue = new List<KeyValuePair<int, string>>();
                lstKeyValue = (dbCon.GFI_AMM_VehicleMaintTypes.AsEnumerable().Select(x =>
                              new KeyValuePair<int, string>
                              (
                                x.MaintTypeId,
                                  x.Description
                              )).ToList());

                return lstKeyValue;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool SaveAssetMaintenance(int assestId,int maintenanceId)
        {
            try
            {
                AssetMaintenaceType obj = new AssetMaintenaceType();
                obj.AssetId = assestId;
                obj.MaintenceId = maintenanceId;
                dbCon.AssetMaintenaceTypes.Add(obj);
                dbCon.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
