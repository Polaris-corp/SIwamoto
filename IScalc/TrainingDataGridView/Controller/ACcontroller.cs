using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingDataGridView.Service;
using System.Data;

namespace TrainingDataGridView.Controller
{
    public class ACcontroller
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
    }
}
