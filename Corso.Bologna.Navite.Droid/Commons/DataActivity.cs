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
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace Corso.Bologna.Navite.Droid.Commons
{
    public class DataActivity<T>: ActivityBase where T : ViewModelBase
    {
        public T ViewModel
        {
            get { return CorsoApp.Locator.GetInstance<T>(); }
        }
    }
}