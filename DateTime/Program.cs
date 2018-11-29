using System;

namespace MyDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string date = "2018-10-18";
            DateTime dateTime = Convert.ToDateTime(date);
            Console.WriteLine(DateTime.Parse("2018-10-26 14:43:52.527").Date == DateTime.Today);
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));
            Console.ReadKey();
        }
    }
}
