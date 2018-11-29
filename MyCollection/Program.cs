using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            #region HashSet
            #endregion
            #region SortedSet
            #endregion
            #region Linked List
            LinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddLast("Hung");
            linkedList.AddLast("Hai");
            linkedList.AddFirst("Huong");
            var node = linkedList.Find("Hung");
            linkedList.AddAfter(node, "HungPrince");
            linkedList.AddBefore(node, "HungPrince1");
            Console.WriteLine("LinkedList");
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
            #endregion
            #region Dictionary
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("once", 1);
            dict.Add("tow", 2);
            dict.Add("three", 3);
            dict.Add("four", 4);
            Console.WriteLine("Dictionary:");
            foreach (KeyValuePair<string, int> pair in dict)
            {
                Console.WriteLine(pair.Key.ToString());
            }
            #endregion
            #region Sorted Dictionary
            SortedDictionary<string, string> sorted = new SortedDictionary<string, string>();
            sorted.Add("1", "Sonoo");
            sorted.Add("3", "Peter");
            sorted.Add("2", "James");
            Console.WriteLine("SortedDictionary:");
            foreach (KeyValuePair<string, string> kv in sorted)
            {
                Console.WriteLine(kv.Key + "= " + kv.Value);
            }
            #endregion
            #region Sorted List
            #endregion
            Console.ReadKey(true);
        }
    }
}
