using System;
using System.IO;

namespace MyDelegate
{
    class Program
    {
        class TestDelegate
        {
            static FileStream fs;
            static StreamWriter sw;

            public delegate void PrintString(string s);

            public static void WriteToScreen(string str)
            {
                Console.WriteLine("The String is {0}", str);
            }

            public static void WriteToFile(string s)
            {
                using (fs = new FileStream("message.txt", FileMode.Append, FileAccess.Write))
                {
                    Console.WriteLine("Open stream on file message.txt");
                    using (sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(s);
                        sw.Flush();
                    }
                }
            }

            public static void SendString(PrintString ps)
            {
                ps("Hello World");
            }

            static void Main(string[] args)
            {
                PrintString ps1 = new PrintString(WriteToScreen);
                PrintString ps2 = new PrintString(WriteToFile);
                SendString(ps1);
                SendString(ps2);
                Console.ReadKey(true);
            }
        }
    }
}