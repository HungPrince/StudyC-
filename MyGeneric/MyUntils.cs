using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    class MyUntils
    {
        public static K GetKey<K, V>(KeyValue<K, V> entry)
        {
            K key = entry.GetKey();
            return key;
        }

        public static V GetValue<K, V>(KeyValue<K, V> entry)
        {
            V value = entry.GetValue();
            return value;
        }

        public static E GetFirstElement<E>(List<E> list, E defaultValue)
        {
            if (list.Count == 0 || list == null)
            {
                return defaultValue;
            }
            E first = list.ElementAt(0);
            return first;
        }

    }
}
