using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Corso.Bologna.ViewModels;
using GalaSoft.MvvmLight.Views;

namespace Corso.Bologna.Navite.Droid
{
    public static class   CorsoApp
    {
        private static ViewModelLocator _viewModelLocator;
        private static NavigationService _navigationService;
        public static ViewModelLocator Locator
        {
            get
            {
                if (_viewModelLocator == null)
                {
                    _viewModelLocator = new ViewModelLocator();
                    _navigationService = new NavigationService();
                    _navigationService.Configure(PageKeys.DetailsPageKey, typeof(DetailsActivity));
                    _viewModelLocator.SetNavigationService(_navigationService);
                }
                return _viewModelLocator;
            }
        }

        public static NavigationService NavigationService
        {
            get { return _navigationService; }
        }
    }
}