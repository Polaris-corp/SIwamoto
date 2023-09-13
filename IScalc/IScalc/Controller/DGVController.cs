using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IScalc.Service;
using System.Data;


namespace IScalc.Controller
{
    public class DGVController
    {
        DGVService dgvService = new DGVService();

        public DataTable IndicateUsersInfo()
        {
            return dgvService.ShowUsersData();
        }

        public DataTable GetDeletedUserInfo()
        {
            return dgvService.ShowDeletedUserData();
        }

        public DataTable GetAllUserInfo()
        {
            return dgvService.ShowAllUserData();
        }
    }
}
