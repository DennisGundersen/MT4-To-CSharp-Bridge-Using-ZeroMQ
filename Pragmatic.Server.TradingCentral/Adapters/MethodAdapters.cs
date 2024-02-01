using Pragmatic.Common.Entities.DTOs;
using Pragmatic.Common.Entities.Helpers;
using Pragmatic.Server.TradingCentral.ZMQ;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace Pragmatic.Server.TradingCentral.Adapters
{
    internal partial class MethodAdapters
    {
        protected CultureInfo culture = CultureInfo.InvariantCulture;
        protected string[] PrepareError(string message)
        {
            return new string[] { Base.RESP_ERROR, message };
        }

        protected string[] PrepareResponse(params string[] data)
        {
            return data.Prepend(Base.RESP_OK).ToArray();
        }

        /*
            Register all of TradingCentral's public methods here (functions as adapters as listed in the AvailableCommands() dictionary)
            Adapters should call the methods in the BusinessLogic of any strategy.
            Incoming data should be deserialized into classes here, and only then passed on to the business logic methods as entities. 
            The results from BusinessLogic should be serialized and returned to the calling client as string[] for safe transfers.
         */
        public string[] RegisterHourglassAccount(string[] args)
        {
            bool success = false;
            int currentPosition = 0;

            // Create blank HourglassAccountRegistrationDTO object
            HourglassAccountRegistrationDTO registrationDTO = new();

            // Deserialize the incoming string[] args into the blank HourglassAccountRegistrationDTO object
            success = Converters.ArrayToHourglassAccountRegistrationDTO(args, ref currentPosition, registrationDTO);

            if (!success) 
            { 
                return PrepareError(String.Format("Argument 0 ({0}) couldn't be parsed as {1}", args[0], "Pragmatic.Common.Entities.DTOs.HourglassAccountRegistrationDTO")); 
            }

            // Call the method in the BusinessLogic class, passing in the HourglassAccountRegistrationDTO dto, and receive the resulting HourglassAccountRegistrationResultDTO dto
            HourglassAccountRegistrationResultDTO result = Strategy.Hourglass.BusinessLogic.Trader.RegisterAccount(registrationDTO);

            // Serialize the HourglassAccountRegistrationResultDTO into a string[], including a prepended "OK" status code, then return it
            string[] retSerialized = PrepareResponse(Converters.HourglassAccountRegistrationResultDTOToString(result).ToArray());

            return retSerialized;
        }

        public string[] RegisterHourglassTrades(string[] args)
        {
            bool success = false;
            int currentPosition = 0;
            //Console.WriteLine("RegisterHourglassTrades() called");

            // Deserialize the incoming string[] args into a List<OrderDTO>
            List<OrderDTO> ordersList = new();
            success = Converters.ArrayToHourglassOrderDTOList(args, ref currentPosition, ref ordersList);
            
            // If the incoming string object couldn't be deserialized, return an error
            if (!success)
            { 
                return PrepareError(String.Format("Argument 0 ordersList({0}) couldn't be parsed as {1}", args[0], "Pragmatic.Common.ZMQTypes.DynamicArray<Pragmatic.Common.Entities.OrderDTO>")); 
            }

            // Ask
            decimal ask;
            success = decimal.TryParse(args[currentPosition++], out ask);
            if (!success)
            {
                return PrepareError(String.Format("Argument 1 Ask ({0}) couldn't be parsed as {1}", args[1], "System.Decimal"));
            }

            // Bid
            decimal bid;
            success = decimal.TryParse(args[currentPosition++], out bid);
            if (!success)
            {
                return PrepareError(String.Format("Argument 2 Bid ({0}) couldn't be parsed as {1}", args[2], "System.Decimal"));
            }

            // Balance
            decimal balance;
            success = decimal.TryParse(args[currentPosition++], out balance);
            if (!success)
            {
                return PrepareError(String.Format("Argument 3 Balance ({0}) couldn't be parsed as {1}", args[3], "System.Decimal"));
            }

            // Equity
            decimal equity;
            success = decimal.TryParse(args[currentPosition++], out equity);
            if (!success)
            {
                return PrepareError(String.Format("Argument 4 Equity ({0}) couldn't be parsed as {1}", args[4], "System.Decimal"));
            }

            // Call the method on the BusinessLogic class, passing the deserialized string[] as a List<OrderDTO>, and receive the resulting List<ChangeOrderDTO>
            List<ChangeOrderDTO> changeOrderItems = Strategy.Hourglass.BusinessLogic.Trader.RegisterTrades(ordersList, ask, bid, balance, equity);
            
            // Serialize the resulting List<ChangeOrderDTO> to a string[], including a prepended "OK" status code, then return it
            string[] results = PrepareResponse(Converters.HourglassChangeOrderDTOToList(changeOrderItems).ToArray());

            return results;

        }

        public string[] GetHourglassAccountOverview(string[] args)
        {
            bool success = false;

            // Create blank HourglassAccountStatisticsDTO object
            HourglassAccountStatisticsDTO statisticsDTO = new();
            
            // Incoming args[0] should be the accountId
            int valInt;
            int accountId = -1;
            try
            {
                success = int.TryParse(args[0], out valInt);
                if (!success) return null;
                accountId = valInt;
            }
            catch (System.Exception e)
            {
              throw new System.Exception("Error parsing accountID from args[0]", e);
            }

            // Call the method in the BusinessLogic class, passing accountId, and receive the resulting HourglassAccountStatisticsDTO
            HourglassAccountStatisticsDTO result = Strategy.Hourglass.BusinessLogic.Trader.GetAccountOverview(accountId);

            // Serialize the resulting HourglassAccountStatisticsDTO into a string[], including a prepended "OK" status code, then return it
            string[] retSerialized = PrepareResponse(Converters.HourglassAccountStatisticsDTOToList(result).ToArray());

            return retSerialized;
        }

    }
}
