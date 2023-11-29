using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventorycontrol.Model
{
    public class TownshipInfoModel
    {
        public TownshipInfoModel()
        {
            Id = 0;
            Name = "";
            Deleted = false;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
    }
}
