using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Views
{
	public partial class Page3View : ContentPage
	{
		public Page3View()
		{
			InitializeComponent();
            ViewModel = App.Locator.Page3;
            base.BindingContext = ViewModel;
        }

        private Page3ViewModel ViewModel { get; set; }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.OnAppearingAsync();
        }

        protected override async void OnDisappearing()
        {
            await ViewModel.OnDisappearingAsync();
            base.OnDisappearing();
        }
    }
}
