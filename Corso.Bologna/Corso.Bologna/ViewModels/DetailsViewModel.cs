using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Bologna.Models;
using Corso.Bologna.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace Corso.Bologna.ViewModels
{
    public class DetailsViewModel: ViewModelBase
    {
        private Recipe _currentrecipe;
        private string _title;
        private INavigationService _navigationService;
        private IRecipeDetailService _recipeDetailService;
        private List<Ingredient> _ingredients;
        private List<Step> _steps;

        public DetailsViewModel(INavigationService navigationService, IRecipeDetailService recipeDetailService)
        {
            _navigationService = navigationService;
            _recipeDetailService = recipeDetailService;
        }
        public string Title
        {
            get { return _title; }
            set { Set(ref _title, value); }
        }

        public Recipe CurrentRecipe
        {
            get { return _currentrecipe; }
            set
            {
                Set(ref _currentrecipe, value);
                Title = _currentrecipe.Name;
                LoadRecipeAsync();
            }
        }

        public List<Ingredient> Ingredients
        {
            get { return _ingredients; }
            set { Set(ref _ingredients, value); }
        }

        public List<Step> Steps
        {
            get { return _steps; }
            set { Set(ref _steps, value); }
        }
       
        private async void LoadRecipeAsync()
        {
            var details = await _recipeDetailService.GetRecipeDetailAsync(CurrentRecipe.id);
            Ingredients = new List<Ingredient>(details.Ingredients);
            Steps = new List<Step>(details.Steps);
        }
    }
}
