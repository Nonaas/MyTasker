using SQLite;

namespace MyTasker.Domain.Models
{
    public class ToDoList
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string? Name { get; set; }
        public bool Done { get; set; } = false;
        public bool Redeemed { get; set; } = false;

        public ToDoList() { }
    }
}
