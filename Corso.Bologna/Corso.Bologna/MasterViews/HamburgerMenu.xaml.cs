using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Corso.Bologna.MasterViews
{
    public partial class HamburgerMenu : ContentPage
    {
        public ListView ItemsListView { get; private set; }
        public HamburgerMenu()
        {
            InitializeComponent();
            ItemsListView = HamburgerMenuListView;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            HamburgerMenuListView.ItemsSource = new List<string>
            {
                "menu 1",
                "menu 2",
                "menu 3"
            };
        }
    }
}
