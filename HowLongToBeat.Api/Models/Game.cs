namespace HowLongToBeat.Api.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string? Title { get; set; }
        public int ClockedTime { get; set; }
        public int TotalPlayTime { get; set; }
        public int TotalPlayTimeWithExtras { get; set; }
        public int Rating { get; set; } // From OpenCritic
        public bool IsCompleted { get; set; } = false;
    } 
}
