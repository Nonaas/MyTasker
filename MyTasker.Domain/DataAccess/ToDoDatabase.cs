namespace MyTasker.Domain.DataAccess
{
    public class ToDoDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public ToDoDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Stats>().Wait();
            _database.CreateTableAsync<ToDo>().Wait();
            _database.CreateTableAsync<ToDoList>().Wait();

            // Init stats
            int statsRows = _database.Table<Stats>().CountAsync().GetAwaiter().GetResult();
            if (statsRows == 0)
            {
                string sql = $"INSERT INTO Stats (ID, CurrentLevel, CurrentXP) VALUES(1, 0, 0);";

                _database.ExecuteAsync(sql).GetAwaiter().GetResult();
            }
        }

        public Task<List<ToDo>> GetToDosAsync(bool done)
        {
            Task<List<ToDo>> loadedTodos =
                _database.Table<ToDo>()
                         .Where(t => t.Done == done 
                                  && t.ToDoListId == 0)
                         .ToListAsync();

            return loadedTodos;
        }

        public async Task<Stats> GetStatsAsync()
        {
            Stats loadedStats = await _database.Table<Stats>()
                                               .FirstOrDefaultAsync();

            return loadedStats;
        }

        public async Task UpdateStatsAsync(int newLevel, int newXP, int newXPforNextLevel)
        {
            string sql = "UPDATE Stats SET CurrentLevel = ?, CurrentXP = ?, XPforNextLevel = ? WHERE Id = 1;";

            await _database.ExecuteAsync(sql, newLevel, newXP, newXPforNextLevel);
        }

        public async Task<int> DeleteAllDoneTodosAsync()
        {
            string sql = "DELETE FROM ToDo WHERE Done = 1;";

            int rowsModified = await _database.ExecuteAsync(sql);

            return rowsModified;
        }

        public Task<int> SaveToDoAsync(ToDo todo)
        {
            Task<int> rowsModified = _database.InsertAsync(todo);

            return rowsModified;
        }

        public Task<int> UpdateToDoAsync(ToDo todo)
        {
            Task<int> rowsModified = _database.UpdateAsync(todo);

            return rowsModified;
        }

        public Task<int> DeleteToDoAsync(ToDo todo)
        {
            Task<int> rowsModified = _database.DeleteAsync(todo);

            return rowsModified;
        }

        public Task<List<ToDoList>> GetTodoListsAsync(bool done)
        {
            Task<List<ToDoList>> loadedTodos =
                _database.Table<ToDoList>()
                         .Where(t => t.Done == done)
                         .ToListAsync();

            return loadedTodos;
        }

        public async Task<List<ToDo>> GetToDosForListAsync(int toDoListId)
        {
            List<ToDo> todoList = await _database.Table<ToDo>()
                                  .Where(t => t.ToDoListId == toDoListId)
                                  .ToListAsync();
            return todoList;
        }

        public Task<int> SaveToDoListAsync(ToDoList todoList)
        {
            Task<int> rowsModified = _database.InsertAsync(todoList);

            return rowsModified;
        }

        public Task<int> UpdateToDoListAsync(ToDoList todoList)
        {
            Task<int> rowsModified = _database.UpdateAsync(todoList);

            return rowsModified;
        }

        public async Task<int> DeleteAllDoneToDoListsAsync()
        {
            string sql = "DELETE FROM ToDoList WHERE Done = 1;";

            int rowsModified = await _database.ExecuteAsync(sql);

            return rowsModified;
        }
    }
}