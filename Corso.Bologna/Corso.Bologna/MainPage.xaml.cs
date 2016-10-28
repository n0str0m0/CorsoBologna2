using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Bologna.Models;
using Xamarin.Forms;

namespace Corso.Bologna
{
    public class Data
    {
        public Data()
        {
            Recipes = new List<Recipe>
            {

                new Recipe {Name = "pizza"},
                new Recipe {Name = "pizza 1"}

            };

        }
        public string Title { get; set; }

        public IList<Recipe> Recipes { get; set; }
    }
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            
            InitializeComponent();
            var data = (Data) Grid.BindingContext;
            var data1 = App.Current.Resources["data"] as Data;
            if (data1 != null)
            {
                data.Recipes.Add(new Recipe { Name = "tortellino2" });
            }
            data.Recipes.Add(new Recipe {Name = "tortellino"});
        }



        
    }
}

