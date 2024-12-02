namespace MyTasker
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void NavigateToTab(string tabTitle)
        {
            foreach (var page in Children)
            {
                if (page.Title == tabTitle)
                {
                    CurrentPage = page;
                    return;
                }
            }
        }
    }
}
