using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace IScalc.Common
{
    class ErrorLog
    {
        public void WriteStackTraceToTxt(Exception ex)
        {
            string errFolderPath = "ErrorLogs";

            if (!Directory.Exists(errFolderPath))
            {
                Directory.CreateDirectory(errFolderPath);
            }

            string errorInfo = $"エラーメッセージ: {ex.Message}" +
                               $"\nスタックトレース:\n{ex.StackTrace}";

            string filePath = Path.Combine(errFolderPath, $"error_{DateTime.Now:yyyyMMdd_HHmmss}.txt");


            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.WriteLine("---エラーログ開始---");
                writer.WriteLine(DateTime.Now.ToString());
                writer.WriteLine(errorInfo);
                writer.WriteLine("---エラーログ終了---");
                writer.WriteLine();
            }
        }
    }
}
