using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Core.ViewModels
{
	public class ViewModelLocator
	{
		static ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			SimpleIoc.Default.Register<MainViewModel>();
			SimpleIoc.Default.Register<HomeViewModel>();
			SimpleIoc.Default.Register<Page2ViewModel>();
            SimpleIoc.Default.Register<Page3ViewModel>();
        }

		public MainViewModel Main
		{
			get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
		}

		public HomeViewModel Home
		{
			get { return ServiceLocator.Current.GetInstance<HomeViewModel>(); }
		}

		public Page2ViewModel Page2
		{
			get { return ServiceLocator.Current.GetInstance<Page2ViewModel>(); }
		}

        public Page3ViewModel Page3
        {
            get { return ServiceLocator.Current.GetInstance<Page3ViewModel>(); }
        }
    }
}
