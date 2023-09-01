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
        
        public DataTable IndicateUsersInfo(DataTable dt)
        {
            return dgvService.ShowUsersData(dt);
        }
    }
}
