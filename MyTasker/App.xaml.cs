using MyTasker.Domain.DataAccess;
using MyTasker.Domain.Models;

namespace MyTasker
{
    public partial class App : Application
    {

        public static ToDoDatabase? Database { get; private set; }
        public static Stats Stats { get => _stats; set => _stats = value; }
        private static Stats _stats = new();

        public App()
        {
            InitializeComponent();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mytasker.db");

            // Inizialize sqlite db
            Database = new ToDoDatabase(dbPath);
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "MyTasker" };
        }
    }
}
