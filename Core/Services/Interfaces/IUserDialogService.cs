using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public enum AlertClickedAction
    {
        Cancel = 0,
        Ok = 1,
    }

    public class AlertCallback
    {
        public AlertClickedAction AlertClickedAction { get; set; }
        public string Text { get; set; }
    }

    public class AlertParameters
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public string OkText { get; set; }
        public string CancelText { get; set; }
        
        public bool ShowCancelButton { get; set; }
    }

    public interface IUserDialogService
    {
        void ShowToast(string message, int secondsduration = 5);
        Task<AlertCallback> ConfirmAsync(string message, string title = "", string okText = "Ok", string cancelText = "Cancel");
        Task<AlertCallback> AlertAsync(AlertParameters param);
        Task<AlertCallback> AlertAsync(string title, string message, string okText = "Ok");
        void ShowLoading(string title, MaskType mask = MaskType.Black);
        void HideLoading();
    }
}
