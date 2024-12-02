namespace MyTasker.Domain.DataAccess
{
    public class PodcastRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public PodcastRepository(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath, false);
            _database.CreateTableAsync<Podcast>().Wait();
        }

        public async Task<List<Podcast>> GetPodcastsAsync()
        {
            List<Podcast> loadedPodcasts =
                await _database.Table<Podcast>()
                               .ToListAsync();

            return loadedPodcasts;
        }

        public Task<int> InsertPodcastAsync(Podcast podcast)
        {
            Task<int> rowsModified = _database.InsertAsync(podcast);

            return rowsModified;
        }

        public Task<int> UpdatePodcastAsync(Podcast podcast)
        {
            Task<int> rowsModified = _database.UpdateAsync(podcast);

            return rowsModified;
        }

    }
}
