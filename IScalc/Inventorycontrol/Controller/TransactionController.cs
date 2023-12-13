using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventorycontrol.Service;
using System.Data;

namespace Inventorycontrol.Controller
{
    public class TransactionController
    {

        TransactionService service = new TransactionService();
        public void RegistrationSchedule(DateTime date,List<int> quantity,int townshipId,int warehouseId,List<int> statusId,List<int> itemId,List<string> itemName)
        {
            for(int i = 0; i < quantity.Count; i++)
            {
                service.RegistrationInfo(date, quantity[i],townshipId, warehouseId, statusId[i], itemId[i], itemName[i]);
            }
        }

        public DataTable GetTransactionInfo(string name, DateTime start, DateTime end, int townshipId, int warehouseId, int statusId)
        {
            return service.SearchTranasctionInfo(name, start, end, townshipId, warehouseId, statusId);
        }
    }
}
