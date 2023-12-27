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
    public class TownshipController
    {

        TownshipService townshipService = new TownshipService();
        public DataTable SearchTownship(TownshipModel township)
        {
            return townshipService.ResultSearchTownship(township);
        }

        public bool RegistrationTownship(TownshipModel township)
        {
            return townshipService.RegistrationTownship(township);
        }

        public bool UpdateTownship(TownshipModel info)
        {
           return townshipService.UpdateTownship(info);
        }
        public int GetTownshipId(string tName)
        {
            return townshipService.GetTownshipId(tName);
        }
        public List<TownshipModel> GetTownshipInfotoCMB()
        {
            return townshipService.GetTownshipInfo();
        }
    }
}
