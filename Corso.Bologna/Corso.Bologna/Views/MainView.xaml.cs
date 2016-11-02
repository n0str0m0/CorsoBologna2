using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Corso.Bologna.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            IListViewController listViewController = this.RecipeListView as IListViewController;
            if (listViewController != null)
            {
                listViewController.ScrollToRequested += ListViewControllerOnScrollToRequested;
            }
        }

        private void ListViewControllerOnScrollToRequested(object sender, ScrollToRequestedEventArgs scrollToRequestedEventArgs)
        {
      
        }
    }
}
