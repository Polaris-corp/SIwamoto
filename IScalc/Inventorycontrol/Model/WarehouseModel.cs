using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventorycontrol.Model
{
    public class WarehouseModel
    {
        public WarehouseModel()
        {
            Id = 0;
            Name = "";
            Townshipid = 0;
            Deleted = false;
            Capacity = 0;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Townshipid { get; set; }
        public bool Deleted { get; set; }
        public int Capacity { get; set; }
    }
}
