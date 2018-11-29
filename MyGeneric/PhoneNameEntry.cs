using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    class PhoneNameEntry:KeyValue<int,string>
    {
        public PhoneNameEntry(int key, string value):base(key,value)
        {

        }
    }
}
