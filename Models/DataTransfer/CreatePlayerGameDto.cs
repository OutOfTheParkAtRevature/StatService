using System;

namespace Models.DataTransfer
{
    public class CreatePlayerGameDto
    {
        public string playerId { get; set; }
        public Guid gameId { get; set; }
        public BaseballStatistic BaseballStatistic { get; set; }

    }
}
