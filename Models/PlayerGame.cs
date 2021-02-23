using System;
using System.ComponentModel;

namespace Models
{
    public class PlayerGame
    {
        [DisplayName("User ID")]
        public Guid UserID { get; set; }
        [DisplayName("Game ID")]
        public Guid GameID { get; set; }
        [DisplayName("Stat Line")]
        public Guid StatLineID { get; set; }
    }
}
