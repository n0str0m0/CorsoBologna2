using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Corso.Bologna.ViewModels;
using Corso.Bologna.Views;
using Xamarin.Forms;

namespace Corso.Bologna
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            NavigationPage navigationPage = new NavigationPage();
            ViewModelLocator locator = (ViewModelLocator)Resources["ViewModelLocator"];
            NavigationService formNavigationService = new NavigationService();
            formNavigationService.Initialize(navigationPage);
            formNavigationService.Configure(PageKeys.DetailsPageKey, typeof(RecipeDetailsView));
            locator.SetNavigationService(formNavigationService);
            navigationPage.PushAsync(new MainView());
            MainPage = navigationPage;
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
