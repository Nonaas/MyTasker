using MyTasker.Domain.DataAccess;
using MyTasker.Domain.Models;

namespace MyTasker
{
    public partial class App : Application
    {

        public static ToDoDatabase? DatabaseTodos { get; private set; }
        public static PodcastRepository? PodcastRepository { get; private set; }
        public static Stats Stats { get => _stats; set => _stats = value; }
        private static Stats _stats = new();

        public static object Data = new();
        public static event EventHandler<object>? OnDataChanged;


        public App()
        {
            InitializeComponent();
            string dbPathTodos = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mytasker.db");
            string dbPathPoddis = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "poddis.db");

            // Inizialize todo db
            DatabaseTodos = new ToDoDatabase(dbPathTodos);

            // Inizialize poddi db
            PodcastRepository = new PodcastRepository(dbPathPoddis);
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "Mein Planer", MinimumHeight = 800 };
        }

        public static void NavigateTo(string tab, object? data = null)
        {
            if (Current.MainPage is MainPage mainPage)
            {
                mainPage.NavigateToTab(tab);

                if(data != null)
                {
                    Data = data;
                    OnDataChanged?.Invoke(null, Data);
                }
            }
        }
    }
}
