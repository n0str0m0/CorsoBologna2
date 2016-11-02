using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Bologna.Models;
using Corso.Bologna.ViewModels;
using Xamarin.Forms;

namespace Corso.Bologna.Views

{
    public partial class RecipeDetailsView 
    {
        public RecipeDetailsView()
        {
            InitializeComponent();
        }

        public RecipeDetailsView(Recipe recipe)
        {
            InitializeComponent();
            var viewModel = BindingContext as DetailsViewModel;
            if (viewModel != null)
            {
                viewModel.CurrentRecipe = recipe;
            }
        }

    }
}
