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

        public string OkButton { get; set; }
        public string CancelButton { get; set; }

        public bool HideOkButton { get; set; }
        public bool HideCancelButton { get; set; }
    }

    public interface IUserDialogService
    {
        void ShowToast(string message);
        Task<bool> ConfirmAsync(string message, string title = "");
        Task<AlertCallback> AlertAsync(AlertParameters parms);
        Task<AlertCallback> AlertAsync(string title, string msg);
    }
}
