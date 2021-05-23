using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Core.Helpers
{
    public static class Constants
    {
        public static string LogDirectoryPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Catering\";
        public static string LogFilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Catering\log.txt";
    }
}
