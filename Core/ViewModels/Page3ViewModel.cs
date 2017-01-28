using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class Page3ViewModel : BaseViewModel
    {
        private IUserDialogService _userDialog;
        public Page3ViewModel(IUserDialogService userDialog) : base("Page 3")
        {
            _userDialog = userDialog;
        }
    }
}
