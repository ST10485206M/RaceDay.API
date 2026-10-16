namespace RaceDay.API.Models
{
    public class Organiser
    {
        public int OrganiserID { get; set; }

        public string Firstname { get; set; } = string.Empty;

        public string Lastname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Phonenumber { get; set; } = string.Empty;
    }
}