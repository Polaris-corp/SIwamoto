using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventorycontrol.Service;
using System.Data;
using Inventorycontrol.Model;

namespace Inventorycontrol.Controller
{
    public class TransactionController
    {
        WarehouseService warehouseService = new WarehouseService();
        TransactionService transactionservice = new TransactionService();
        public void RegistrationSchedule(List<ScheduleModel> schedules)
        {
            for(int i = 0; i < schedules.Count; i++)
            {
                ScheduleModel schedule = schedules[i];
                transactionservice.RegistrationInfo(schedule);
            }
        }

        public DataTable GetTransactionInfo(string name, DateTime start, DateTime end, int townshipId, int warehouseId, int statusId)
        {
            return transactionservice.SearchTranasctionInfo(name, start, end, townshipId, warehouseId, statusId);
        }

        public List<WarehouseModel> GetWarehouseList()
        {
            return warehouseService.GetWarehouseInfo();
        }
    }
}
