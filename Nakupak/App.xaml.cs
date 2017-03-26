using Xamarin.Forms;

namespace Nakupak
{
	public partial class App : Application
	{
		public static string Message;
		public static int Price;

		public App()
		{
			InitializeComponent();

			MainPage = new NakupakPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		private static Database _database;

		public static Database Database
		{
			get
			{
				if (_database == null)
				{
					_database = new Database(DependencyService.Get<IFileHelper>().GetLocalFilePath("Nakupak.db3"));
				}
				return _database;
			}
		}
	}
}
