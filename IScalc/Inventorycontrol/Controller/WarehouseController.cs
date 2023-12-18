using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Inventorycontrol.Service;
using Inventorycontrol.Model;

namespace Inventorycontrol.Controller
{
    public class WarehouseController
    {
        WarehouseService service = new WarehouseService();
        public DataTable SearchWarehouse(WarehouseModel warehouse,string townshipName)
        {
            return service.ResaultSearchWarehouse(warehouse,townshipName);
        }

        public DataTable GetWarehouse(int townshipId)
        {
            return service.SearchWarehouse(townshipId);
        }

        public void RegistrationWarehouse(WarehouseModel warehouse)
        {
            service.InsertWarehouseInfo(warehouse);
        }

        public void UpdateWarehouse(WarehouseModel warehouse)
        {
            service.UpdateWarehouse(warehouse);
        }

        public void DeleteWarehouse(WarehouseModel warehouse)
        {
            service.DeleteWarehouse(warehouse);
        }

        public int GetWarehouseId(string name)
        {
            return service.GetWarehouseId(name);
        }

        public int GetWarehouseCapacity(int id)
        {
            return service.GetWarehouseCapacity(id);
        }

        public List<string> GetAllWarehouseName()
        {
            return service.GetAllWarehouseName();
        }

    }
}
