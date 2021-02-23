namespace Models.DataTransfer
{
    public class CreatePlayerGameDto
    {
        public Guid playerId { get; set; }
        public Guid gameId { get; set; }
        public BaseballStatistic BaseballStatistic { get; set; }

    }
}
