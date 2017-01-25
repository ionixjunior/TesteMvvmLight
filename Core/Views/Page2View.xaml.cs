using Core.Interfaces;
using Xamarin.Forms;

namespace Core.Views
{
	public partial class Page2View : ContentPage
	{
		public Page2View(int codigo)
		{
			InitializeComponent();
			BindingContext = App.Locator.Page2;
			(BindingContext as IViewModelParameter).SetParameter(codigo);
		}
	}
}
