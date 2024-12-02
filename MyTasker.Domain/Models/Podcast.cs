namespace MyTasker.Domain.Models
{
    public class Podcast
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string? Author { get; set; }
        public string? ImageUrl { get; set; }
        public string? RssFeedUrl { get; set; }

        public Podcast() { }
    }
}
