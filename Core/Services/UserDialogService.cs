using Acr.UserDialogs;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UserDialogService : IUserDialogService
    {
        private IUserDialogs _acrDialog;
        public UserDialogService(IUserDialogs acrDialog)
        {
            _acrDialog = acrDialog;
        }

        public Task<AlertCallback> AlertAsync(AlertParameters param)
        {
            var tcsAlertCallback = new TaskCompletionSource<AlertCallback>();

            if (param.ShowCancelButton)
                _acrDialog.Confirm(new ConfirmConfig
                {
                    Title = param.Title,
                    Message = param.Message,
                    OkText = param.OkText,
                    CancelText = param.CancelText,
                    OnConfirm = (s) =>
                    {
                        tcsAlertCallback.SetResult(new AlertCallback
                        {
                            AlertClickedAction = s ? AlertClickedAction.Ok : AlertClickedAction.Cancel
                        });
                    }
                });
            else
                _acrDialog.Alert(new AlertConfig
                {
                    Title = param.Title,
                    Message = param.Message,
                    OkText = param.OkText,
                    OnOk = () =>
                    tcsAlertCallback.SetResult(new AlertCallback
                    {
                        AlertClickedAction = AlertClickedAction.Ok
                    })
                });
            
            return tcsAlertCallback.Task;
        }

        public Task<AlertCallback> AlertAsync(string title, string message, string okText = "Ok")
        {
            var tcsAlertCallback = new TaskCompletionSource<AlertCallback>();

            _acrDialog.Alert(new AlertConfig
            {
                Title = title,
                Message = message,
                OkText = okText,
                OnOk = () =>
                tcsAlertCallback.SetResult(new AlertCallback
                {
                    AlertClickedAction = AlertClickedAction.Ok
                })
            });

            return tcsAlertCallback.Task;
        }

        public Task<AlertCallback> ConfirmAsync(string message, string title = "", 
            string okText = "Ok", string cancelText = "Cancel")
        {
            var tcsAlertCallback = new TaskCompletionSource<AlertCallback>();

            _acrDialog.Confirm(new ConfirmConfig
            {
                Title = title,
                Message = message,
                OkText = okText,
                CancelText = cancelText,
                OnConfirm = s =>
                tcsAlertCallback.SetResult(new AlertCallback
                {
                    AlertClickedAction = s ? AlertClickedAction.Ok : AlertClickedAction.Cancel
                })
            });

            return tcsAlertCallback.Task;
        }

        public void HideLoading()
        {
            _acrDialog.HideLoading();
        }

        public void ShowLoading(string title, MaskType mask = MaskType.None)
        {
            _acrDialog.ShowLoading(title, mask);
        }

        public void ShowToast(string title, int secondsduration = 5, string description = null)
        {
            _acrDialog.Toast(new ToastConfig(new ToastEvent(), title, description).
                SetDuration(TimeSpan.FromSeconds(secondsduration)));
        }
    }
}
