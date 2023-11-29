using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventorycontrol.Model
{
    public class ItemInfoModel
    {
        public ItemInfoModel()
        {
            Id = 0;
            Name = "";
            Count = 0;
            Deleted = false;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public bool Deleted { get; set; }

    }
}
