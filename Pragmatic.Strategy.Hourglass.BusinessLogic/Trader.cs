using Pragmatic.Common.Entities.DTOs;
using Pragmatic.Common.Entities.Enums;

namespace Pragmatic.Strategy.Hourglass.BusinessLogic
{
    public class Trader
    {
        public static HourglassAccountRegistrationResultDTO RegisterAccount(HourglassAccountRegistrationDTO accountRegistration)
        {
            // TODO: Connect to the real business logic
            var result = new HourglassAccountRegistrationResultDTO { AccountId = 1, StartFactor = 0, LastOrderClose = 2, StartingBalance = 123.45M, StepGrowthFactor = 0.1M };
            return result;
        }

        public static List<ChangeOrderDTO> RegisterTrades(List<OrderDTO> orders, decimal ask, decimal bid, decimal balance, decimal equity)
        {
            // TODO: Connect to the real business logic
            List<ChangeOrderDTO> result = new();
            foreach (var item in orders)
            {
                result.Add(new ChangeOrderDTO
                {
                    Ticket = item.Ticket,
                    OrderType = item.OrderType,
                    Lots = Decimal.ToDouble(item.Lots),
                    OpenRate = Decimal.ToDouble(item.OpenRate),
                    StopLossRate = Decimal.ToDouble(item.StopLossRate),
                    TakeProfitRate = Decimal.ToDouble(item.TakeProfitRate),
                    OrderFunction = 1,
                    Action = 5
                });
            }

            return result;
        }

        public static HourglassAccountStatisticsDTO GetAccountOverview(int accountId)
        {
            // TODO: Connect to the real business logic
            var result = new HourglassAccountStatisticsDTO 
            { 
                Balance = 123.45M, Equity = 123.45M, Longs = 1, Shorts = 2, OrderCount = 3, CurrentStep = 4, TradingSize = 5, NextLot = 6, NextLotIncrease = 7, 
                UpRate = 8, UpEquity = 9, UpBalance=10, UpLongs=11, UpShorts=12, 
                TopRate = 13, TopEquity = 14, TopBalance = 15, TopLongs = 16, TopShorts = 17,
                CenterRate = 18, CenterEquity = 19, CenterBalance = 20, CenterLongs = 21, CenterShorts = 22,
                DownRate = 23, DownEquity = 24, DownBalance = 25, DownLongs = 26, DownShorts = 27,
                BottomRate = 28, BottomEquity = 29, BottomBalance = 30, BottomLongs = 31, BottomShorts = 32
            };
            return result;
        }

    }
}
