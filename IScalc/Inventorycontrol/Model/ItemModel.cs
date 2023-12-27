using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventorycontrol.Model.InterFace;

namespace Inventorycontrol.Model
{
    public class ItemModel : IitemInfoInterface
    {
        public ItemModel()
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
