using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingDataGridView.Model
{
    public class UsersModel
    {
        public UsersModel()
        {
            Id = "";
            Name = "";
            Pwd = "";
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }

    }
}
