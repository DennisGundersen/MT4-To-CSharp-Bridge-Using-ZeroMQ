using Pragmatic.Common.Entities;
using Pragmatic.Common.Entities.DTOs;
using Pragmatic.Common.Entities.Enums;
using System;
using Pragmatic.Strategy.Hourglass.BusinessLogic.Helpers;
namespace Pragmatic.Strategy.Hourglass.Client
{
    public static class MockExtensions
    {
        public static OrderDTO MockOrder(int accountId, int j)
        {
            ++j;
            return new()
            {
                Ticket = j,
                OrderType = 1,
                Lots = 0.10M,
                OpenTime = Tools.ConvertDateTimeToEpochInt(DateTime.Now),
                CloseTime = Tools.ConvertDateTimeToEpochInt(DateTime.Now),
                Symbol = "USDCAD",
                OpenRate = 1.3500M,
                CloseRate = 1.3550M,
                StopLossRate = 0,
                TakeProfitRate = 1.3550M,
                Swap = 0,
                Commission = 1.00M,
                Profit = j * 2.34M,
                Comment = "Mocked #" + j.ToString(),
                AccountId = accountId
            };
        }
    }
}
