using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IScalc.Service;
using System.Data;

namespace IScalc.Controller
{
    public class AccountController
    {
        DGVService dgvService = new DGVService();

        public void InsertAccountInfo(string Name, string Pwd)
        {
            dgvService.InsertAcInfo(Name, Pwd);
        }

        public void UpdateAccountInfo(int id, string name, string pwd)
        {
            dgvService.UpdateAccountInfo(id, name, pwd);
        }

        public void DeleteAccountInfo(int id)
        {
            dgvService.DeleteAccountInfo(id);
        }

        public void RestorationAccountInfo(int id, string name, string pwd)
        {
            dgvService.RestorationAccountInfo(id, name, pwd);
        }

        public DataTable GetAllUserInfo()
        {
            return dgvService.ShowAllUserData();
        }

        public DataTable GetDeletedUserInfo(bool deleted)
        {
            return dgvService.ShowDeletedUserData(deleted);
        }

        public DataTable GetUserInfo(bool arrive)
        {
            return dgvService.ShowUsersData(arrive);
        }
    }
}
