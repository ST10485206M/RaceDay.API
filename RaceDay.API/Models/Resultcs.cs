using System.ComponentModel.DataAnnotations;

namespace RaceDay.API.Models
{
    public class Result
    {
        [Key]
        public int ResultsID { get; set; }

        public int ParticipantID { get; set; }

        public int EventID { get; set; }

        public int Position { get; set; }

        public TimeSpan FinishTime { get; set; }
    }
}