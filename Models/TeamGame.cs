using System;
using System.ComponentModel;

namespace Models
{
    public class TeamGame
    {
        [DisplayName("Team ID")]
        public Guid TeamID { get; set; }
        [DisplayName("Game ID")]
        public Guid GameID { get; set; }
        [DisplayName("Stat Line")]
        public Guid StatLineID { get; set; }
    }
}
