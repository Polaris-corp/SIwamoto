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

        public DataTable IndicateUsersInfo(bool arrive)
        {
            return dgvService.ShowUsersData(arrive);
        }

        public DataTable GetDeletedUserInfo(bool arrive)
        {
            return dgvService.ShowUsersData(arrive);
        }

        public DataTable GetAllUserInfo()
        {
            return dgvService.ShowAllUserData();
        }
    }
}
