using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingDataGridView.Service;

namespace TrainingDataGridView.Controller
{
    public class DGVController
    {

        UsersService dgvService = new UsersService();
        
        public DataTable IndicateUsersInfo()
        {
             return dgvService.ShowUsersData();
        }

        public DataTable GetDeletedUserInfo()
        {
            return dgvService.ShowDeletedUserData();
        }
    }
}
