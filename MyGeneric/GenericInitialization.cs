using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    class GenericInitialization
    {
        public void DoSomething<T>() where T : new()
        {
            T t = new T();
        }

        public void ToDoSomeThing<K>() where K:KeyValue<K, string>, new()
        {
            K key = new K();
        }

        public T DoDefault<T>()
        {
            return default(T);
        }
    }
}
