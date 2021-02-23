namespace Models.DataTransfer
{
    public class PlayerGameStatDto
    {
        public Guid playerId { get; set; }
        public Guid gameId { get; set; }
        public BaseballStatistic baseballStat { get; set; }
    }
}
