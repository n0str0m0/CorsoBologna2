using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Bologna.Models;
using Corso.Bologna.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Corso.Bologna.ViewModels
{
    public class DetailsViewModel: ViewModelBase
    {
        private Recipe _currentrecipe;
        private string _title;
        private INavigationService _navigationService;
        private IRecipeDetailService _recipeDetailService;
        private IList<Ingredient> _ingredients;
        private IList<Step> _steps;

        public DetailsViewModel(INavigationService navigationService, IRecipeDetailService recipeDetailService)
        {
            _navigationService = navigationService;
            _recipeDetailService = recipeDetailService;
            Ingredients = new ObservableCollection<Ingredient>();
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

        public IList<Ingredient> Ingredients
        {
            get { return _ingredients; }
            set { Set(ref _ingredients, value); }
        }

        public IList<Step> Steps
        {
            get { return _steps; }
            set { Set(ref _steps, value); }
        }
       
        private async void LoadRecipeAsync()
        {
            var details = await _recipeDetailService.GetRecipeDetailAsync(CurrentRecipe.id);
            Ingredients.Clear();
            foreach (var item in details.Ingredients)
            {
                Ingredients.Add(item);
            }
            Steps = new List<Step>(details.Steps);
        }
    }
}
