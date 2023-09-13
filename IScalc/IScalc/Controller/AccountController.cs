using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IScalc.Service;
using System.Data;
using IScalc.Model;

namespace IScalc.Controller
{
    public class AccountController
    {
        DGVService dgvService = new DGVService();
        

        public void InsertAccountInfo(UsersModel user)
        {
            dgvService.InsertAcInfo(user);
        }

        public void DeleteAccountInfo(int id)
        {
            dgvService.DeleteAccountInfo(id);
        }

        public void UpdateAccountInfo(UsersModel user)
        {
            dgvService.UpdateAccountInfo(user);
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
