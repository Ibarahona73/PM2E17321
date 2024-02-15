namespace PM2E17321
{
    public partial class App : Application
    {
        static Controllers.SitiosController database;

        public static Controllers.SitiosController Database
        {
            get
            {
                if (database == null)
                {
                    database = new Controllers.SitiosController();
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            
        }
    }
}
