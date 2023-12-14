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
        public DataTable SearchWarehouse(string name,string townshipName,bool deleted)
        {
            return service.ResaultSearchWarehouse(name,townshipName,deleted);
        }

        public DataTable GetWarehouse(int townshipId)
        {
            return service.SearchWarehouse(townshipId);
        }

        public void RegistrationWarehouse(string name,int townshipId,int capacity)
        {
            service.InsertWarehouseInfo(name,townshipId,capacity);
        }

        public void UpdateWarehouse(WarehouseModel warehouse)
        {
            service.UpdateWarehouse(warehouse);
        }

        public void DeleteWarehouse(WarehouseModel warehouse)
        {
            service.DeleteWarehouse(warehouse);
        }

        public List<string> GetWarehouseName(int id)
        {
            return service.GetWarehouseName(id);
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
