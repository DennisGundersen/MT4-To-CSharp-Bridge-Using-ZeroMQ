namespace Pragmatic.Common.Entities.DTOs
{
    public class HourglassAccountStatisticsDTO
    {
        public decimal Balance { get; set; }
        public decimal Equity { get; set; }
        public decimal Longs { get; set; }
        public decimal Shorts { get; set; }
        public int OrderCount { get; set; }
        public int CurrentStep { get; set; }
        public decimal TradingSize { get; set; }
        public decimal NextLot { get; set; }
        public decimal NextLotIncrease { get; set; }

        public decimal UpRate { get; set; }
        public decimal UpEquity { get; set; }
        public decimal UpBalance { get; set; }
        public decimal UpLongs { get; set; }
        public decimal UpShorts { get; set; }

        public decimal TopRate { get; set; }
        public decimal TopEquity { get; set; }
        public decimal TopBalance { get; set; }
        public decimal TopLongs { get; set; }
        public decimal TopShorts { get; set; }

        public decimal CenterRate { get; set; }
        public decimal CenterEquity { get; set; }
        public decimal CenterBalance { get; set; }
        public decimal CenterLongs { get; set; }
        public decimal CenterShorts { get; set; }

        public decimal DownRate { get; set; }
        public decimal DownEquity { get; set; }
        public decimal DownBalance { get; set; }
        public decimal DownLongs { get; set; }
        public decimal DownShorts { get; set; }

        public decimal BottomRate { get; set; }
        public decimal BottomEquity { get; set; }
        public decimal BottomBalance { get; set; }
        public decimal BottomLongs { get; set; }
        public decimal BottomShorts { get; set; }

    }
}
