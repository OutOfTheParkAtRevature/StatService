﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TeamGame
    {
        [Key]
        [DisplayName("Team ID")]
        public string TeamID { get; set; }
        [DisplayName("Game ID")]
        public Guid GameID { get; set; }
        [DisplayName("Stat Line")]
        public Guid StatLineID { get; set; }
    }
}
