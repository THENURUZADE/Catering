using Catering.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.Web.Helpers
{
    public static class EnumarationHelper<T> where T : BaseModel
    {
        public static void Numerate(List<T> collection, int startIndex = 1)
        {
            for (int i = startIndex - 1; i < collection.Count; i++)
            {
                collection[i].No = i + 1;
            }
        }
    }
}
