using Core.Helpers;
using Core.Models;
using Core.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.ViewModels
{
	public class HomeViewModel : BaseViewModel
    {
		private INavigationService _navigation;
		private IDialogService _dialog;
        private HttpResult<JsonPlaceModel> _result;

        public HomeViewModel(INavigationService navigation, IDialogService dialog) : base("Home View")
		{
			_navigation = navigation;
			_dialog = dialog;

            _result = new HttpResult<JsonPlaceModel>(System.Net.HttpStatusCode.NoContent);
            IsBusy = true;
            Task.Run(async () =>
            {
                var httpService = new HttpService();
                httpService.URI = "https://jsonplaceholder.typicode.com";
                _result = await httpService.Get<JsonPlaceModel>("/posts", new HttpHeader("Accept", "application/json"));
            }).Wait();
            IsBusy = false;
            LoadList = _result.Result;
        }

        IList<JsonPlaceModel> _listItens;
        public IList<JsonPlaceModel> LoadList
        {
            get
            {
                return _result.Result;
            }
            set
            {
                if (Set(() => LoadList, ref _listItens, value))
                    RaisePropertyChanged();
            }
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
