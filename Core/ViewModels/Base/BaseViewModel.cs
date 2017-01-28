using GalaSoft.MvvmLight;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    [ImplementPropertyChanged]
    public class BaseViewModel : ViewModelBase
    {
        public BaseViewModel(string title)
        {
            Title = title;
        }

        public string Title { get; set; }

        public bool IsBusy { get; set; }

        public virtual async Task OnAppearingAsync()
        {
        }

        public virtual async Task OnDisappearingAsync()
        {
        }
    }
}
