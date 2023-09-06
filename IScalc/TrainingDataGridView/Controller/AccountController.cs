using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingDataGridView.Service;
using System.Data;

namespace TrainingDataGridView.Controller
{
    public class AccountController
    {
        UsersService dgvService = new UsersService();

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

        public DataTable GetAllUserInfo()
        {
            return dgvService.ShowAllUserData();
        }

        public DataTable GetDeletedUserInfo()
        {
            return dgvService.ShowDeletedUserData();
        }
    }
}
