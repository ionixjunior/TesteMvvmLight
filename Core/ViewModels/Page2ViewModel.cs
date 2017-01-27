using Core.Interfaces;
using Core.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace Core.ViewModels
{
	public class Page2ViewModel : BaseViewModel, IViewModelParameter
	{
        private IUserDialogService _userDialog;
        public Page2ViewModel(IUserDialogService userDialog) : base("Page 2")
        {
            _userDialog = userDialog;
        }

		public void SetParameter(object parameter)
		{
			System.Diagnostics.Debug.WriteLine(parameter);
		}

        private RelayCommand _alertCommand;
        public RelayCommand AlertCommand
        {
            get
            {
                return _alertCommand ?? (_alertCommand = new RelayCommand(
                    async () => 
                    {
                        var resp = await _userDialog.AlertAsync(new AlertParameters
                        {
                            Title = "foo",
                            OkText = "ok",
                            Message = "bar bar bar XPTO",
                            CancelText = "cancel",
                            ShowCancelButton = false
                        });
                        System.Diagnostics.Debug.WriteLine(resp.AlertClickedAction.ToString());
                    }
                ));
            }
        }

        private RelayCommand _toastCommand;
        public RelayCommand ToastCommand
        {
            get
            {
                return _toastCommand ?? (_toastCommand = new RelayCommand(
                    () =>
                    {
                        _userDialog.ShowToast("asdfasdf");
                    }
                ));
            }
        }
    }
}
