using Nancy;
using System;
using System.Threading;

namespace NancySelfHostServer
{
    public class DefaultModule : NancyModule
    {
        public static int InFlight = 0;

        public DefaultModule()
        {
            Get["/{delay:int}"] = parameters =>
            {
                try
                {
                    Interlocked.Increment(ref InFlight);
                    Console.WriteLine("Got request. Waiting");
                    Thread.Sleep((int)parameters.delay);
                    return "Hello World";
                }
                finally
                {
                    Interlocked.Decrement(ref InFlight);
                }
            };
        }
    }
}
