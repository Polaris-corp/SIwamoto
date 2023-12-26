using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventorycontrol.Model.InterFace
{
    public interface IitemInfoInterface
    {
         int Id { get; set; }
         string Name { get; set; }
         bool Deleted { get; set; }
    }
}
