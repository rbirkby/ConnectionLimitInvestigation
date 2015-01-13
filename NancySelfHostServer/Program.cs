using Nancy.Hosting.Self;
using System;
using System.Net;
using System.Threading;

namespace NancySelfHostServer
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Nancy Self-Host";

            ThreadPool.SetMinThreads(100, 100);
            ThreadPool.SetMaxThreads(100, 100);
            //ServicePointManager.UseNagleAlgorithm = false;
            //ServicePointManager.DefaultConnectionLimit = 100;

            using (var host = new NancyHost(new HostConfiguration { UrlReservations = new UrlReservations { CreateAutomatically = true } }, new Uri("http://localhost:3000")))
            {
                host.Start();

                while(true)
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("{0} inflight requests.", DefaultModule.InFlight);
                }
            }
        }
    }
}
