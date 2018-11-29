using System;


namespace OwinConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Microsoft.Owin.Hosting.WebApp.Start<Startup>("http://localhost:5000"))
            {
                Console.WriteLine("Press [Enter] to quit");
                Console.ReadLine();
            }
        }
    }
}
