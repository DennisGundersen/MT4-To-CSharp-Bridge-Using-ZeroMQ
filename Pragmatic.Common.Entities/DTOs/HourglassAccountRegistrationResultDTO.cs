namespace Pragmatic.Common.Entities.DTOs
{
    public class HourglassAccountRegistrationResultDTO
    {
        public int AccountId { get; set; }
        public decimal StepGrowthFactor { get; set; }
        public decimal StartingBalance { get; set; }
        public int StartFactor { get; set; }
        // DateTime must be ints of seconds since UnixEpoc due to MT4
        public int LastOrderClose { get; set; } //could be also datetime if serialized correctly

    }
}
