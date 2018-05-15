using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace TestApp3
{
	public partial class App : Application
	{
		public App ()
		{
            //NavigationPage navPage = new NavigationPage(new MainPage());
            MainPage = new MainPage();
            
            InitializeComponent();
        }

		protected override void OnStart ()
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
