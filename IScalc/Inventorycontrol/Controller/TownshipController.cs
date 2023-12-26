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
        public DataTable SearchTownship(TownshipInfoModel township)
        {
            return service.ResultSearchTownship(township);
        }

        public void RegistrationTownship(TownshipInfoModel township)
        {
            service.RegistrationTownship(township);
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
        public List<TownshipInfoModel> GetTownshipInfotoCMB()
        {
            return service.GetTownshipInfo();
        }
    }
}
