using System.ComponentModel.DataAnnotations;

namespace MyTasker.Domain.Models
{
    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string? Text { get; set; }
        public bool WholeDay { get; set; }
        public string? Color { get; set; }

        public Appointment() { }
    }
}
