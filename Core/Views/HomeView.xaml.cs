﻿using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Views
{
    public partial class HomeView : ContentPage
    {
		public HomeView()
		{
			InitializeComponent();
            ViewModel = App.Locator.Home;
            base.BindingContext = ViewModel;
        }

        private HomeViewModel ViewModel { get; set; }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.OnAppearing();
        }

        protected override async void OnDisappearing()
        {
            await ViewModel.OnDisappearing();
            base.OnDisappearing();
        }
    }
}
