using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventorycontrol.Model
{
     public class StatusModel
    {
        public StatusModel()
        {
            Id = 0;
            Status = "";
        }
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
