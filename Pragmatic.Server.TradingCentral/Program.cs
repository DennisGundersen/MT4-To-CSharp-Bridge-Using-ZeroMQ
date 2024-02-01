using Pragmatic.Server.TradingCentral.Adapters;
using Pragmatic.Server.TradingCentral.ZMQ;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Pragmatic.Server.TradingCentral
{

    /*
        This is the entry point of the Trading Central server.
        It is responsible for:
            - Initializing the server
            - Configuring the server
            - Registering commands that expose methods (for any strategy) using "adapters"
            - Starting the server   
            - Stopping the server   
     */
    public class Program
    {
        private static MethodAdapters commands = new();
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing...");
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            Console.WriteLine("Culture set to invariant");
            using (Base server = new BridgeZeroMQ())
            {
                var address = args.Length == 0 || String.IsNullOrEmpty(args[0]) ? "tcp://127.0.0.1:9001" : args[0];
                Dictionary<string, string> defaultConfig = new()
                {
                    {"address", address }
                };

                // Wire up the CTRL+C handler
                Console.CancelKeyPress += (sender, e) =>
                {
                    Console.WriteLine("Cancel Key Pressed");
                    server.Stop();
                };
                server.Configure(defaultConfig);
                Console.WriteLine(String.Format("Starting server {0} listening on `{1}`", server.Name, defaultConfig["address"]));
                
                // Register all custom commands as defined in the AvailableCommands() Dictionary below. ("adapters" mapped to methods).
                server.AddCommands(AvailableCommands());

                server.Start();
            }
        }

        /* List all custom command names that should be available on the Trading Central */
        private static Dictionary<string, Base.Cmd> AvailableCommands()
        {
            return new() {
                { "RegisterHourglassAccount", commands.RegisterHourglassAccount },
                { "RegisterHourglassTrades", commands.RegisterHourglassTrades },
                { "GetHourglassAccountOverview", commands.GetHourglassAccountOverview }

                
           };
        }
    }
}
