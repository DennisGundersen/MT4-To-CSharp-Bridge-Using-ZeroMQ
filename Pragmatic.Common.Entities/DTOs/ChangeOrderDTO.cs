namespace Pragmatic.Common.Entities.DTOs
{
    public class ChangeOrderDTO
    {
        public int Ticket { get; set; }
        public int OrderType { get; set; }
        public double Lots { get; set; }
        public double OpenRate { get; set; }
        public double StopLossRate { get; set; }
        public double TakeProfitRate { get; set; }
        // TODO: Consider change to enum against issues with serialization
        public int OrderFunction { get; set; }
        public int Action { get; set; }
 
    }

}
