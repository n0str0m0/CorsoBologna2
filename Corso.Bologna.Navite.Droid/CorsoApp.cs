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
        public static ViewModelLocator Locator
        {
            get
            {
                if (_viewModelLocator == null)
                {
                    _viewModelLocator = new ViewModelLocator();
                    var navigationService = new NavigationService();
                    navigationService.Configure(PageKeys.DetailsPageKey, typeof(MainActivity));
                    _viewModelLocator.SetNavigationService(navigationService);
                }
                return _viewModelLocator;
            }
        }
    }
}