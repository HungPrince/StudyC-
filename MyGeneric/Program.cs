using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    class Program
    {

        public static T[] FilledArray<T> (T value, int count)
        {
            T[] ret = new T[count];
            for (int i = 0; i < count; i++)
            {
                ret[i] = value;
            }
            return ret;
        }

        static void Main(string[] args)
        {
            KeyValuePair<int, string> entry = new KeyValuePair<int, string>(0967680605, "HungPrince");

            PhoneNameEntry pn = new PhoneNameEntry(0903804230, "HungPrince1");

            KeyValue<int, string> kv1 = new KeyValue<int, string>(131150080, "Tome");
            KeyValue<int, string> kv2 = new KeyValue<int, string>(19001570, "Jerry");

            int phone = entry.Key;
            string name = entry.Value;

            Console.WriteLine("Phone= " + phone + "/name=" + name);
            Console.WriteLine("Phone= " + pn.GetKey() + "/name=" + pn.GetValue());

            List<KeyValue<int, string>> list = new List<KeyValue<int, string>>();
            list.Add(kv1);
            list.Add(kv2);

            KeyValue<int, string> firstEntry = MyUntils.GetFirstElement(list, null);
            Console.WriteLine("Generice method");
            Console.WriteLine("Phone= " + MyUntils.GetKey(kv1));
            if(firstEntry != null)
            {
                Console.WriteLine("Value= " + firstEntry.GetValue());
            }


            string value = "Hello";
            string[] filledArray = FilledArray<string>(value, 10);
            foreach (var s in filledArray)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey(true);
        }
    }
}
