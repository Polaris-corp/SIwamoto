using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IScalc.Common
{
   public static class ErrorLogItem
    {
        public const string ErrorDirectoryPath = @".\ErrorLogs";
        public const string ErrorFileName = "errorLogs.txt";
        public const string ErrorInfo = "エラーメッセージ: {0}" 
                                      + "\r\nスタックトレース:\r\n{1}";

        public const string StartErrorMessage = "---エラーログ開始---";
        public const string EndErrorMessage = "---エラーログ終了---";

        public const bool OverWrite = false;
        public const bool Append = true;
    }
}
