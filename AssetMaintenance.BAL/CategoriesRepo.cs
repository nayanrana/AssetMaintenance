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
    public class CategoriesRepo
    {
        AssetMaintenanceEntities dbCon;

        public CategoriesRepo()
        {
            dbCon = new AssetMaintenanceEntities();
        }

        public List<CategoriesDto> getAllCategories()
        {
            var categoryList = dbCon.GFI_AMM_VehicleMaintCat.AsEnumerable().ToList().Select(x => new CategoriesDto
            {
                CategoryId = x.MaintCatId,
                Description = x.Description
            });

            return categoryList.ToList();
        }

    }
}
