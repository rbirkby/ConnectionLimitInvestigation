using Microsoft.Owin.Hosting;
using System;
using System.Threading;

namespace NancyOwinServer
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Nancy Owin self-host";

            ThreadPool.SetMinThreads(100, 100);
            ThreadPool.SetMaxThreads(100, 100);
            //ServicePointManager.UseNagleAlgorithm = false;
            //ServicePointManager.DefaultConnectionLimit = 100;

            var url = "http://+:3000";

            // netsh http add urlacl url=http://+:3000/ user=everyone

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Running on {0}", url);


                while (true)
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("{0} inflight requests.", DefaultModule.InFlight);
                }
            }
        }
    }
}
