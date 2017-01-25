using Xamarin.Forms;

namespace Core.Views
{
	public partial class HomeView : ContentPage
	{
		public HomeView()
		{
			InitializeComponent();
			BindingContext = App.Locator.Home;
		}
	}
}
