using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main()
        {
            ThreadPool.SetMaxThreads(100, 100);
            ThreadPool.SetMinThreads(100, 100);
            //ServicePointManager.UseNagleAlgorithm = false;
            //ServicePointManager.DefaultConnectionLimit = 100;

            Thread.Sleep(3000);
            MakeRequests().Wait();
        }

        private static async Task MakeRequests()
        {
            var tasks = Enumerable.Range(0, 20)
                .Select(i => {
                    Console.WriteLine(i);
                    return WebRequest.Create("http://localhost:3000/3000").GetResponseAsync()
                        .ContinueWith(r => r.Result.Close());
                });

            await Task.WhenAll(tasks.ToArray());
        }
    }
}
