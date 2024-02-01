using NetMQ;
using NetMQ.Sockets;
using Pragmatic.Common.Entities.DTOs;
using Pragmatic.Common.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace Pragmatic.Strategy.Hourglass.Client
{
    internal class Program
    {
        private static RequestSocket Client;
        private static readonly Encoding encoding = Encoding.UTF8;
        private static readonly TimeSpan reconnectIntervalMax = new(0, 0, 30); //when total time exceeds this value stop retrying connect
        private static readonly TimeSpan reconnectInterval = new(0, 0, 2); //interval at which try to reconnect to server
        private static readonly TimeSpan receiveTimeout = new(50000); //0.5s (number of 100ns ticks, 1s = 10 000 ticks)
        private static readonly bool DBG_ZMQ = true;
        private static string CommLastError = String.Empty;

        static void Main(string[] args)
        {
            Console.WriteLine("Initializing...");
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            Console.WriteLine("Culture set to invariant");

            using (Client = new())
            {
                var address = args.Length == 0 || String.IsNullOrEmpty(args[0]) ? "tcp://127.0.0.1:9001" : args[0];
                // Setup socket variables
                CommInitializeSocket();
                //
                Client.Connect(address);

                Console.WriteLine("Starting run of Hourglass strategy test client");

                // Register Hourglass Account
                Console.WriteLine("TestRegisterHourglassAccountOnServer() starting...");
                HourglassAccountRegistrationResultDTO result = TestRegisterHourglassAccountOnServer();
                int stop = 0;
                Console.WriteLine("TestRegisterHourglassAccountOnServer() finished!");

                // Register Hourglass orders and receive changes
                List<ChangeOrderDTO> changes = new();
                Console.WriteLine("TestRegisterHourglassTradesOnServer() starting...");
                changes = TestRegisterHourglassTradesOnServer();
                stop = 0;
                Console.WriteLine("TestRegisterHourglassAccountOnServer() finished!");

                Console.WriteLine("TestRegisterHourglassTradesOnServer(5, true) starting...");
                changes = TestRegisterHourglassTradesOnServer(5, true);
                stop = 0;
                Console.WriteLine("TestRegisterHourglassAccountOnServer(5, true) finished!");

                // Get Hourglass Account Overview
                Console.WriteLine("TestGetHourglassAccountOverviewOnServer() starting...");
                HourglassAccountStatisticsDTO overview = TestGetHourglassAccountOverviewOnServer(result.AccountId);
                stop = 0;
                Console.WriteLine("TestGetHourglassAccountOverviewOnServer() finished!");
            }
        }

        static HourglassAccountRegistrationResultDTO TestRegisterHourglassAccountOnServer()
        {
            HourglassAccountRegistrationResultDTO result = new();
            HourglassAccountRegistrationDTO registration = new();
            FillHourglassAccountRegistrationDTO(registration);
            
            bool success = false;
            success = RegisterHourglassAccountOnServer(result, registration);

            if (success)
            {
                Console.WriteLine("Received RegisterHourglassAccountOnServer Result");
                //result.Dump();
            }
            else
            {
                result.AccountId = -1;
            }

            return result;
        }


        static List<ChangeOrderDTO> TestRegisterHourglassTradesOnServer(int mockOrders = 0, bool mock = false)
        {
            int maxOrderCount = mockOrders;
            List<OrderDTO> orders = new();
            List<ChangeOrderDTO> changeOrders = new();

            double ask = 1.3502;
            double bid = 1.3501;
            double balance = 5000.0;
            double equity = 2900;
            int accountId = 1;

            int j = -1; //it will always have index of last element
                        //other option would be j = 0, and change ++j to j++, then j would be count of elements in array
            
            for (int i = maxOrderCount - 1; i >= 0; --i)
            {
                if (mock)
                {
                    orders.Add(MockExtensions.MockOrder(accountId, ++j));
                }
            }

            bool ok = RegisterHourglassTradesOnServer(changeOrders, orders, ask, bid, balance, equity);
            if (ok)
            {
                Console.WriteLine("Result of RegisterHourglassTradesOnServer (Count = {0})", changeOrders.Count);
                foreach (var item in changeOrders)
                {
                    //item.Dump();
                }
                Console.WriteLine("End of Result of RegisterHourglassTradesOnServer");

                return changeOrders.ToList();
            }

            return null;
        }

        static HourglassAccountStatisticsDTO TestGetHourglassAccountOverviewOnServer(int accountId)
        {
            HourglassAccountStatisticsDTO result = new();
            bool success = false;
            success = GetHourglassAccountOverviewOnServer(result, accountId);

            if (success)
            {
                Console.WriteLine("Received GetHourglassAccountOverviewOnServer Result");
                //result.Dump();
            }

            return result;
        }


        #region Executing commands on Server
        static bool RegisterHourglassAccountOnServer(HourglassAccountRegistrationResultDTO result, HourglassAccountRegistrationDTO registration)
        {
            bool success = false;
            const string commandName = "RegisterHourglassAccount";
            List<string> payload = new(); // Send buffer

            // Add command name and serialized HourglassAccountRegistrationDTO object to the send buffer
            payload.Add(commandName);
            //payload.AddRange(registration.Serialize());
            success = Converters.HourglassAccountRegistrationDTOToList(ref payload, registration);

            // Send the command to TradingCentral with the payload[] and receive the response[] (a result dto)
            string[] response = CommSendCommand(payload, out success);
            if (success)
            {
                //CommShowResponse(commandName, response); //this is for debugging only - dump received buffer
                if (response[0] == "OK")
                {
                    //On successful response from the server, convert the received string[], response, into an AccountRegistrationResultDTO and return it
                    int currentPosition = 1; // Starting from [1], as [0] is the response code "OK"
                    // Convert the received string[] into an AccountRegistrationResultDTO and return it
                    success = Converters.ArrayToHourglassAccountRegistrationResultDTO(response, ref currentPosition, result);
                    return success;
                    //return result.Deserialize(response, ref currentPosition);
                }
                else
                {
                    Console.WriteLine("{0} Error: `{1}`", commandName, response[1]);
                }
            }
            else
            {
                Console.WriteLine("{0} no response - error: `{1}`", commandName, CommLastError);
            }
            return false;
        }

        static void FillHourglassAccountRegistrationDTO(HourglassAccountRegistrationDTO registration)
        {
            registration.AccountNumber = 123456;
            registration.AccountName = "DEV";
            registration.Symbol = "USDCAD";
            registration.TradingLotSize = 0.01M;
            registration.ExtremeTopRate = 1.5M;
            registration.NormalTopRate = 1.4M;
            registration.CenterRate = 1.31M;
            registration.NormalBottomRate= 1.2M;
            registration.ExtremeBottomRate = 1.0M;
            registration.MaxPlacementDistance = 300;
            registration.TestUpToRate = 1.375M;
            registration.TestDownToRate = 1.305M;
            registration.TestPipsUp= 300;
            registration.TestPipsDown = 300;
            registration.BalancerMinPlacementDistanceLongs = 100;
            registration.BalancerMinPlacementDistanceShorts = 100;
            registration.LongStabilizerSizeFactor = 1;
            registration.ShortStabilizerSizeFactor = 1;
            registration.LongBalancerSizeFactor = 0;
            registration.ShortBalancerSizeFactor = 0;
            registration.PrimerSizeFactor = 3;
            registration.BalancerStopLossPips = 50;
            registration.SecurePips = 50;
            registration.AutoLotIncrease = false;
            registration.AutoLotSafeEQLevel = 40;
            registration.TakeProfit = 49;
            registration.TradeMidTerm = false;
            registration.FixedSpread = 1;
            registration.ExtraLongBuffer = 1;
            registration.ExtraShortBuffer = 1;
            registration.WarningLevel = 50;
            registration.HeartbeatMonitorTimer = 15;
            registration.DatabaseLogTimer = 5;
            registration.AutoCloseExtremes = false;
            registration.RunBalancers = false;
            registration.RunStabilizers = true;
            registration.RunBreakouts = false;
            registration.RunWhiplash = false;
            registration.RunPrimers = true;
            registration.GMTOffset = 2;
            registration.UsePoint = 0.00001M;
            registration.RateDecimalNumbersToShow = 4;
            registration.IsAccountMaster = true;
            registration.IsSymbolMaster = true;
            registration.ScreenshotTimer = 5;
            registration.MaxWeight= 20;
        }

        public static bool RegisterHourglassTradesOnServer(List<ChangeOrderDTO> result, List<OrderDTO> orders, double ask, double bid, double balance, double equity)
        {
            bool r = false;
            const string commandName = "RegisterHourglassTrades";
            List<string> payload = new(); //send buffer
            payload.Add(commandName);

            // Add number of orders to the send buffer
            int ordersCount = orders.Count;
            payload.Add(ordersCount.ToString());

            foreach (var item in orders)
            {
                payload.Add(item.Ticket.ToString());
                payload.Add(item.OrderType.ToString());
                payload.Add(item.Lots.ToString());
                payload.Add(item.OpenTime.ToString());
                payload.Add(item.CloseTime.ToString());
                payload.Add(item.Symbol);
                payload.Add(item.OpenRate.ToString());
                payload.Add(item.CloseRate.ToString());
                payload.Add(item.StopLossRate.ToString());
                payload.Add(item.TakeProfitRate.ToString());
                payload.Add(item.Swap.ToString());
                payload.Add(item.Commission.ToString());
                payload.Add(item.Profit.ToString());
                payload.Add(item.Comment);
                payload.Add(item.AccountId.ToString());
            }

            payload.Add(ask.ToString());
            payload.Add(bid.ToString());
            payload.Add(balance.ToString());
            payload.Add(equity.ToString());

            var responseArray = CommSendCommand(payload, out r);
            if (r)
            {
                //CommShowResponse(commandName, resp); //this is for debugging only - dump received buffer
                if (responseArray[0] == "OK")
                {
                    //region Deserialization - convert received strings into right types
                    int currentPosition = 2; // Starting from [2], as [0] is the response code "OK" and [1] is the number of changes
                    
                    int changesCount = 0;
                    bool success = int.TryParse(responseArray[1], out changesCount);
                    if (!success)
                    {
                        return false;
                    }
                    
                    for (int i = 0; i < changesCount; i++)
                    {
                        ChangeOrderDTO changeOrder = new();
                        changeOrder.Ticket = int.Parse(responseArray[currentPosition++]);
                        changeOrder.OrderType = int.Parse(responseArray[currentPosition++]);
                        changeOrder.Lots = double.Parse(responseArray[currentPosition++]);
                        changeOrder.OpenRate = double.Parse(responseArray[currentPosition++]);
                        changeOrder.StopLossRate = double.Parse(responseArray[currentPosition++]);
                        changeOrder.TakeProfitRate = double.Parse(responseArray[currentPosition++]);
                        changeOrder.OrderFunction = int.Parse(responseArray[currentPosition++]);
                        changeOrder.Action = int.Parse(responseArray[currentPosition++]);
                        result.Add(changeOrder);
                    }
                    //endregion
                }
                else
                {
                    Console.WriteLine("{0} Error: `{1}`", commandName, responseArray[1]);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("{0} no response - error: `{1}`", commandName, CommLastError);
                return false;
            }

            return true;
        }

        static bool GetHourglassAccountOverviewOnServer(HourglassAccountStatisticsDTO result, int accountId)
        {
            bool success = false;
            const string commandName = "GetHourglassAccountOverview";
            List<string> payload = new(); // Send buffer

            // Add command name and accountId to the send buffer
            payload.Add(commandName);
            payload.Add(accountId.ToString());

            // Send the command to TradingCentral with the payload and receive the response
            string[] response = CommSendCommand(payload, out success);
            if (success)
            {
                if (response[0] == "OK")
                {
                    //On successful response from the server, convert the received string[], response, into an HourglassAccountStatisticsDTO and return it
                    int currentPosition = 1; // Starting from [1], as [0] is the response code "OK"
                    //return result.Deserialize(response, ref currentPosition);
                    success = Converters.ArrayToHourglassAccountStatisticsDTO(response, ref currentPosition, result);
                    return success;
                }
                else
                {
                    Console.WriteLine("{0} Error: `{1}`", commandName, response[1]);
                }
            }
            else
            {
                Console.WriteLine("{0} no response - error: `{1}`", commandName, CommLastError);
            }
            return false;
        }
        #endregion


        #region Internals of communication (Client)
        private static string[] CommSendCommand(List<string> payload, out bool result)
        {
            result = false;
            if (SendCommandInternal(payload))
            {
                return ReceiveResponseInternal(out result);
            }
            return Array.Empty<string>();
        }

        private static bool SendCommandInternal(List<string> payload)
        {
            int last = payload.Count - 1;
            for (int i = 0; i < last; ++i)
            {
                Client.SendMoreFrame(payload[i]);
            }
            Client.SendFrame(payload[last]);
            return true;
        }

        private static string[] ReceiveResponseInternal(out bool received, int retries = 3, int retryInterval = 1000)
        {
            List<string> response = new();
            received = CommReceiveLazyPirate(ref response, retries, retryInterval);
            return response.ToArray();
        }


        private static bool CommReceiveLazyPirate(ref List<string> response, int retries = 3, int retryInterval = 1000)
        {
            bool received = false;
            while (retries > 0)
            {
                --retries;
                if (DBG_ZMQ)
                {
                    Console.WriteLine("(#{0}) Waiting for response", retries);
                }
                received = Client.TryReceiveMultipartStrings(receiveTimeout, encoding, ref response);
                if (DBG_ZMQ)
                {
                    Console.WriteLine("(#{0}) Response available: {1}", retries, received);
                }
                if (received)
                {
                    //CommReceiveLazyPirate_PrintResponse(msg, retries);
                    /*
                    if(StringSubstr(msg.getData(), 0, 3) == "ERR")
                    {
                        CommLastError = msg.getData();
                        return false;
                    }
                    */
                    return true;
                }
                Thread.Sleep(retryInterval);
            }
            return false;
        }


        private static bool CommInitializeSocket()
        {
            /*
            commClient.setTimeout(connectTimeout); //timeout during connection
            commClient.setReceiveTimeout(receiveTimeout); //timeout during receiving
            commClient.setSendTimeout(sendTimeout); //timeout during sending
            */
            Client.Options.ReconnectInterval = reconnectInterval; //interval at which try to reconnect to server
            Client.Options.ReconnectIntervalMax = reconnectIntervalMax; //when total time exceeds this value stop retrying connect
            Client.Options.Linger = TimeSpan.Zero;
            //When Relaxed is set to true Correlated should be also enabled to avoid receiving incorrect responses
            Client.Options.Correlate = true; //add id of message, response is ignored if values don't match
            Client.Options.Relaxed = true; //allows to send another frame even when didn't received response - should be used with above setting 

            return true;
        }
        #endregion
    }
}