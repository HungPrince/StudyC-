using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    class Student
    {
        public int Rollno;
        public string Name;
        public Student(int rollno, string name)
        {
            this.Rollno = rollno;
            this.Name = name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fileStream = new FileStream("serializeable.txt", FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                //Student s = new Student(101, "sonoo");
                //formatter.Serialize(fileStream, s);
                //Console.WriteLine("Serialized successfully !");
                //fileStream.Close();
                Student s1 = (Student)formatter.Deserialize(fileStream);
                Console.WriteLine(s1.Name);
                Console.WriteLine(s1.Rollno);

                Console.ReadKey(true);
            }
        }
    }
}
