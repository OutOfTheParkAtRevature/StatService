using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class BaseballStatistic
    {
        [Key]
        [DisplayName("StatLine ID")]
        public Guid StatLineID { get; set; }
        [DisplayName("Batting ave")]
        public decimal BattingAve { get; set; }
        public int Runs { get; set; }
        public decimal RBI { get; set; }
        public int Hits { get; set; }
        public int Steals { get; set; }
        public decimal ERA { get; set; }
        [DisplayName("Strike Outs")]

        public int StrikeOuts { get; set; }
        public int Saves { get; set; }
    }
}
