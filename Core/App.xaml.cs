using Acr.UserDialogs;
using Core.Services;
using Core.Services.Interfaces;
using Core.ViewModels;
using Core.Views;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;

namespace Core
{
	public partial class App : Application
	{
		private static ViewModelLocator _locator;
		public static ViewModelLocator Locator
		{
			get { return _locator ?? (_locator = new ViewModelLocator());}
		}

		public App()
		{
			InitializeComponent();

			var navigation = new NavigationService();
			navigation.Configure(AppViews.Page2View, typeof(Page2View));
			navigation.Configure(AppViews.Page3View, typeof(Page3View));

            SimpleIoc.Default.Register<INavigationService>(() => navigation);
            //SimpleIoc.Default.Register<IDialogService>(() =>  new DialogService());
            //SimpleIoc.Default.Register<IUserDialogs>(() => UserDialogs.Instance);
            SimpleIoc.Default.Register<IUserDialogService>(() => new UserDialogService(UserDialogs.Instance));

            var navPage = new NavigationPage(new HomeView());
			navigation.Initialize(navPage);
			//dialog.Initialize(navPage);

			MainPage = navPage;
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
	}
}
