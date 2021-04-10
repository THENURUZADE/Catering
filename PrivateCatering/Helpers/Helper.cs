using PrivateCatering.Core.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateCatering.Helpers
{
    public static class Helper
    {
        public static void Log(Exception ex)
        {
            Directory.CreateDirectory(Constants.LogDirectoryPath);

            using (var writer = File.AppendText(Constants.LogFilePath))
            {
                writer.WriteLine(DateTime.Now.ToString());
                writer.WriteLine(ex.ToString());
                writer.WriteLine();
                writer.WriteLine();
            }
        }
    }
}
