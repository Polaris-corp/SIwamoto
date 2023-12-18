using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventorycontrol.Model
{
    public class ScheduleModel
    {
        public ScheduleModel()
        {
            Id = 0;
            Schedule = DateTime.Now;
            Itemquantity = 0;
            Townshipid = 0;
            Warehouseid = 0;
            Statusid = 0;
            Itemid = 0;
            Deleted = false;
        }
        public int Id { get; set; }

        public DateTime Schedule { get; set; }

        public int Itemquantity { get; set; }

        public int Townshipid { get; set; }

        public int Warehouseid { get; set; }

        public int Statusid { get; set; }

        public int Itemid { get; set; }

        public bool Deleted { get; set; }
    }
}
