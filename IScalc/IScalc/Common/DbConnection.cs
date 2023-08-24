using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IScalc.Common
{
    //データベースに接続するために必要な情報　※本来はここには用意しない
    public static class DbConnection
    {
        public const string connectionString = "Server = localhost;Database = test;Uid = root1;Pwd = 1105";
    }
}
