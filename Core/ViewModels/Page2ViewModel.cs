using Core.Interfaces;
using GalaSoft.MvvmLight;

namespace Core.ViewModels
{
	public class Page2ViewModel : ViewModelBase, IViewModelParameter
	{
		public void SetParameter(object parameter)
		{
			System.Diagnostics.Debug.WriteLine(parameter);
		}
	}
}
