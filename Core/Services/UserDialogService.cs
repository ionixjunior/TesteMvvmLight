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
        public Task<AlertCallback> AlertAsync(AlertParameters parms)
        {
            throw new NotImplementedException();
        }

        public Task<AlertCallback> AlertAsync(string title, string msg)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ConfirmAsync(string message, string title = "")
        {
            throw new NotImplementedException();
        }

        public void ShowToast(string message)
        {
            throw new NotImplementedException();
        }
    }
}
