namespace MyTasker.Domain.Models
{
    public class ToDo
    {
        public string Description { get; set; }
        public bool Done { get; set; }

        public ToDo(string description, bool done)
        {
            Description = description;
            Done = done;
        }
    }
}
