using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventorycontrol.Service;

namespace Inventorycontrol.Controller
{
    public class Receive_ShipingController
    {

        Receive_ShipingService service = new Receive_ShipingService();
        public void RegistrationSchedule(DateTime date,List<int> quantity,int warehouseId,List<int> statusId,List<int> itemId,List<string> itemName)
        {
            for(int i = 0; i < quantity.Count; i++)
            {
                service.RegistrationInfo(date, quantity[i], warehouseId, statusId[i], itemId[i], itemName[i]);
            }
        }
    }
}
