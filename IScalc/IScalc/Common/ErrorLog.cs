﻿using System;
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
        public void WriteStackTraceToTxt(Exception ex,DateTime tryLoginTime)
        {

            if (!Directory.Exists(ErrorLogItem.ErrorDirectoryPath))
            {
                Directory.CreateDirectory(ErrorLogItem.ErrorDirectoryPath);
            }

            
            string errorInfo = (string.Format(ErrorLogItem.ErrorInfo, ex.Message, ex.StackTrace));

            string filePath = Path.Combine(ErrorLogItem.ErrorDirectoryPath, ErrorLogItem.ErrorFileName);


            using (StreamWriter writer = new StreamWriter(filePath, ErrorLogItem.Append))
            {
                writer.WriteLine(ErrorLogItem.StartErrorMessage);
                writer.WriteLine(tryLoginTime.ToString());
                writer.WriteLine(errorInfo);
                writer.WriteLine(ErrorLogItem.EndErrorMessage);
                writer.WriteLine();
            }
        }
    }
}
