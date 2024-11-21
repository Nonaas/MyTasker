using SQLite;

namespace MyTasker.Domain.Models
{
    public class Stats
    {
        [PrimaryKey]
        public int ID { get; set; } = 1;
        public int CurrentLevel { get; set; } = 0;
        public int CurrentXP { get; set; } = 0;
        public int XPforNextLevel { get; set; } = 100;

        public Stats() { }
    }
}
