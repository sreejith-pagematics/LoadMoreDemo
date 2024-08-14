using NeedHelp.Pages;

namespace LoadMoreDemoNew
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FriendDetailsPage();
        }
    }
}
