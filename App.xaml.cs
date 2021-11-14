using Xamarin.Forms;

namespace MyFirstApp
{
    // That is our app/application
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            // Main page of application will initialize a shell, this will give us fly of navigation automatically
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
