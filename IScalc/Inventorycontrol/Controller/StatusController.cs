using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventorycontrol.Service;

namespace Inventorycontrol.Controller
{
    public class StatusController
    {
        StatusService statusService = new StatusService();
        
        public void RegistrationStatus(int status)
        {
            statusService.RegistrationStatusInfo(status);
        }

        public List<int> GetStatusId(int count)
        {
            return statusService.GetStatusIdList(count);
        }
    }
}
