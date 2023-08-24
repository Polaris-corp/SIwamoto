using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IScalc.Model
{
    /// <summary>
    /// Historyテーブルのデータを取得するためのクラス
    /// </summary>
    public class HistoryModel
    {
        public DateTime Logtime { get; set; }
        public bool Results { get; set; }
    }
}
