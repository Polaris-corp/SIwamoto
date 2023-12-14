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

        TownshipService service = new TownshipService();
        public DataTable SearchTownship(string name,bool deleted)
        {
            return service.ResultSearchTownship(name,deleted);
        }

        public void RegistrationTownship(string name)
        {
            service.RegistrationTownship(name);
        }

        public void UpdateTownship(TownshipInfoModel info)
        {
            service.UpdateTownship(info);
        }

        public void DeleteTownship(TownshipInfoModel info)
        {
            service.DeleteTownship(info);
        }

        public List<string> GetTownshipName()
        {
            return service.GetTownshipName();
        }

        public List<int> GetAllTownshipId()
        {
            return service.GetAllTownshipId();
        }
        public int GetTownshipId(string tName)
        {
            return service.GetTownshipId(tName);
        }
        public Dictionary<string, int> GetTownshipInfotoCMB()
        {
            return service.GetTownshipInfoToCMB();
        }
    }
}
