using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Helpers
{
    public class CollectionNumerator<T>
    {
        public static void Numerate(ObservableCollection<T> collection, int startIndex = 0)
        {
            Type type = typeof(T);
            PropertyInfo propertyInfo =  type.GetProperty("No");

            for (int i = startIndex; i < collection.Count; i++)
            {
                propertyInfo.SetValue(collection[i], i + 1);
            }
        }
        public static void Numerate(List<T> collection, int startIndex = 0)
        {
            Type type = typeof(T);
            PropertyInfo propertyInfo = type.GetProperty("No");

            for (int i = startIndex; i < collection.Count; i++)
            {
                propertyInfo.SetValue(collection[i], i + 1);
            }
        }
    }
}
