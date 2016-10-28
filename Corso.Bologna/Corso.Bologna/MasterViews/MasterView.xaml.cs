using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Corso.Bologna
{
    public partial class MasterView 
    {
        public MasterView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            HamburgerMenu.ItemsListView.ItemSelected += ItemsListViewOnItemSelected;
        }

        private void ItemsListViewOnItemSelected(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
        {
            this.Detail = new MainPage();
        }
    }
}
