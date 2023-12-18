using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventorycontrol.Service;
using Inventorycontrol.Model;

namespace Inventorycontrol.Controller
{
    public class StatusController
    {
        StatusService statusService = new StatusService();
        
       public List<StatusModel> GetStatusList()
        {
            return statusService.GetStatuses();
        }
    }
}
