using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace counter
{
	public partial class App : Application
	{
        public static ServerConfiguration ServerConfig;
        public static RestService ServerAPI;
        public static DynamicMenu Menu;

        public App ()
		{
            ServerConfig = new ServerConfiguration();
            ServerAPI = new RestService();

			InitializeComponent();

			MainPage = new MainPage();
		}

        protected async override void OnStart()
        {
            // Handle when your app starts
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
