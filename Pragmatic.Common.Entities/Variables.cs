using System;

namespace Pragmatic.Common.Entities
{
    public partial class Variables
    {
        public int Id { get; set; }
        public decimal TradingLotSize { get; set; } = 0; //= 1
        public decimal ExtremeTopRate { get; set; } = 0; //= 2
        public decimal NormalTopRate { get; set; } = 0; //= 3
        public decimal CenterRate { get; set; } = 0; //= 4
        public decimal NormalBottomRate { get; set; } = 0; //= 5
        public decimal ExtremeBottomRate { get; set; } = 0; //= 6

        public int MaxPlacementDistance { get; set; } = 0; //+ 7
        public decimal TestUpToRate { get; set; } = 0; //= 8
        public decimal TestDownToRate { get; set; } = 0; //= 9
        public int TestPipsUp { get; set; } = 300; //= 10
        public int TestPipsDown { get; set; } = 300; //= 11
        public int BalancerMinPlacementDistanceLongs { get; set; } = 0; // 12
        public int BalancerMinPlacementDistanceShorts { get; set; } = 0; // 13

        public int LongStabilizerSizeFactor { get; set; } = 0; //= 14
        public int ShortStabilizerSizeFactor { get; set; } = 0; //= 15
        public int LongBalancerSizeFactor { get; set; } = 0; //= 16
        public int ShortBalancerSizeFactor { get; set; } = 0;  //= 17
        public int PrimerSizeFactor { get; set; } = 3; //= 18
        public int BalancerStopLossPips { get; set; } = 200; //= 19
        public int SecurePips { get; set; } = 0; //= 20

        public bool AutoLotIncrease { get; set; } = false; //= 21
        public int AutoLotSafeEQLevel { get; set; } = 100; //= 22
        public int TakeProfit { get; set; } = 49; //= 23
        public bool TradeMidTerm { get; set; } = false; //= 24
        public int FixedSpread { get; set; } = 1; //= 25
        public int ExtraLongBuffer { get; set; } = 1; //= 26
        public int ExtraShortBuffer { get; set; } = 1; //= 27
        
        public int WarningLevel { get; set; } = 0; //= 28
        public int HeartbeatMonitorTimer { get; set; } = 0; //= 29
        public int DatabaseLogTimer { get; set; } = 0; //= 30
        public bool AutoCloseExtremes { get; set; } = false; //= 31
        
        public bool RunBalancers { get; set; } = false; //= 32
        public bool RunStabilizers { get; set; } = true; //= 33
        public bool RunBreakouts { get; set; } = true; //= 34
        public bool RunWhiplash { get; set; } = false; //= 35
        public bool RunPrimers { get; set; } = false; //= 36
        
        public int GMTOffset { get; set; } = 0; //= 37
        public decimal UsePoint { get; set; } = 0; //+ 38
        public int RateDecimalNumbersToShow { get; set; } = 0; //+ 39
        public bool IsAccountMaster { get; set; } = false; //+ 40
        public bool IsSymbolMaster { get; set; } = false; //+ 41


        public int ScreenshotTimer { get; set; } = 5; //= 42
        public decimal MaxWeight { get; set; } = 20; //= 43
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public virtual Account Account { get; set; }
    }
}
