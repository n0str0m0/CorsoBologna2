using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Bologna.Services;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Corso.Bologna.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<IRecipeService, RecipeService>();
            //SimpleIoc.Default.Register<IRecipeService, FakeRecipeService>();
            SimpleIoc.Default.Register<MainViewModel>();

        }

        public MainViewModel MainViewModel
        {
            get
            {

                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

  
    }

}
