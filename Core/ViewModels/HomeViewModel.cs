using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Core.ViewModels
{
	public class HomeViewModel : ViewModelBase
	{
		private INavigationService _navigation;
		private IDialogService _dialog;

		public HomeViewModel(INavigationService navigation, IDialogService dialog)
		{
			_navigation = navigation;
			_dialog = dialog;
		}

		private string _nome;
		public string Nome
		{
			get { return _nome; }
			set
			{
				if (Set(() => Nome, ref _nome, value))
					RaisePropertyChanged();
			}
		}

		private RelayCommand _navigatePage2Command;
		public RelayCommand NavigatePage2Command
		{
			get
			{
				return _navigatePage2Command ?? (_navigatePage2Command = new RelayCommand(
					() => { _navigation.NavigateTo(AppViews.Page2View, 5); }
				));
			}
		}

		private RelayCommand _navigatePage3Command;
		public RelayCommand NavigatePage3Command
		{
			get
			{
				return _navigatePage3Command ?? (_navigatePage3Command = new RelayCommand(
					() => { _navigation.NavigateTo(AppViews.Page3View); }
				));
			}
		}

		private RelayCommand _showMessageCommand;
		public RelayCommand ShowMessageCommand
		{
			get
			{
				return _showMessageCommand ?? (_showMessageCommand = new RelayCommand(
					async () => await _dialog.ShowMessage("Esta é a mensagem!", "Título")
				));
			}
		}
	}
}
