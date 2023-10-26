using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Common
{
    public class DGVsource
    {

        public int Rank { get; set; }

        public string Name { get; set; }

        public TimeSpan ClearTime { get; set; }
        
        public DGVsource(int rank, string name, TimeSpan cleartime)
        {
            Rank = rank;

            Name = name;

            ClearTime = cleartime;
        }
    }
}
