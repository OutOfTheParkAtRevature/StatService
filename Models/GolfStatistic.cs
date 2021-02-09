using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GolfStatistic
    {
        [Key]
        [DisplayName("StatLine ID")]
        public Guid StatLineID { get; set; }
        [DisplayName("Score To Par")]
        public int ScoreToPar { get; set; }
        [DisplayName("Drive Distance")]
        public int DriveDistance { get; set; }
        [DisplayName("Drive Accuracy")]
        public int DriveAccuracy { get; set; }
        public int GIR { get; set; }
        [DisplayName("Puts per GIR")]
        public int PutsperGIR { get; set; }
        public int Eagles { get; set; }
        public int Birdies { get; set; }
        public int Bogeys { get; set; }
        [DisplayName("Sand Saves")]
        public int SandSaves { get; set; }
        public int Scrambles { get; set; }
    }
}
