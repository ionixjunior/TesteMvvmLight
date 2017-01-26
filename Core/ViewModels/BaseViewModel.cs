using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    //[ImplementPropertyChanged]
    public class BaseViewModel : ViewModelBase
    {
        public BaseViewModel(string title)
        {
            Title = title;
        }

        public string Title { get; set; }

        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                if (Set(() => IsBusy, ref _isBusy, value))
                    RaisePropertyChanged();
            }
        }

        public virtual async Task OnAppearing()
        {
        }

        public virtual async Task OnDisappearing()
        {
        }
    }
}
