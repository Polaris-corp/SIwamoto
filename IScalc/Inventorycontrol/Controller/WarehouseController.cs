using Inventorycontrol.Model;
using Inventorycontrol.Service;
using System.Collections.Generic;
using System.Data;

namespace Inventorycontrol.Controller
{
    public class WarehouseController
    {
        WarehouseService warehouseService = new WarehouseService();
        TownshipService townshipService = new TownshipService();
        public DataTable SearchWarehouse(WarehouseModel warehouse)
        {
            return warehouseService.ResaultSearchWarehouse(warehouse);
        }
        public List<TownshipModel> GetTownshipModels()
        {
            return townshipService.GetTownshipInfo();
        }
        public DataTable GetWarehouse(int townshipId)
        {
            return warehouseService.SearchWarehouse(townshipId);
        }
        public int GetTownshipId(string townshipName)
        {
            return townshipService.GetTownshipId(townshipName);
        }
        public bool RegistrationWarehouse(WarehouseModel warehouse)
        {
            return warehouseService.InsertWarehouseInfo(warehouse);
        }

        public bool UpdateWarehouse(WarehouseModel warehouse)
        {
            return warehouseService.UpdateWarehouse(warehouse);
        }
    }
}
