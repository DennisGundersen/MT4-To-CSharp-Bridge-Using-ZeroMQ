using System;

namespace Pragmatic.Common.Entities.DTOs
{
    public class OrderDTO
    {
        public int Ticket { get; set; }                 // 1
        public int OrderType { get; set; }              // 2
        public decimal Lots { get; set; }               // 3
        public int OpenTime { get; set; }               // 4
        public int CloseTime { get; set; }              // 5
        public string Symbol { get; set; }              // 6
        public decimal OpenRate { get; set; }           // 7    
        public decimal CloseRate { get; set; }          // 8
        public decimal StopLossRate { get; set; }       // 9
        public decimal TakeProfitRate { get; set; }     // 10
        public decimal Swap { get; set; }               // 11
        public decimal Commission { get; set; }         // 12
        public decimal Profit { get; set; }             // 13
        public string Comment { get; set; }             // 14
        public int AccountId { get; set; }              // 15


    }
}
