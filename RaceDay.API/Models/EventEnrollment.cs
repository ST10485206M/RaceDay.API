using System.ComponentModel.DataAnnotations;

namespace RaceDay.API.Models
{
    public class EventEnrollment
    {
        [Key]
        public int EnrollmentID { get; set; }

        public int ParticipantID { get; set; }

        public int EventID { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}