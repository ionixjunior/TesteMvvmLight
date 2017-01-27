using Core.Interfaces;
using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Views
{
	public partial class Page2View : ContentPage
	{
		public Page2View(int codigo)
		{
			InitializeComponent();
            ViewModel = App.Locator.Page2;
            BindingContext = ViewModel;
			(BindingContext as IViewModelParameter).SetParameter(codigo);
		}

        private Page2ViewModel ViewModel { get; set; }

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
