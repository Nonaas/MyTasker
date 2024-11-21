using SQLite;

namespace MyTasker.Domain.Models
{
    public class ToDo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string? Description { get; set; }
        public bool Done { get; set; } = false;
        public bool Redeemed { get; set; } = false;

        public ToDo() { }
    }
}
