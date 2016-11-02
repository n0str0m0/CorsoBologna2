using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Corso.Bologna.Models;
using Corso.Bologna.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Corso.Bologna.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        private IList<Recipe> _recipes;
        private Recipe _selecedRecipe;
        private int _selectedIndex;
        private ICommand _reloadCommand;
        private ICommand _pagingCommand;
        private IRecipeService _recipeService;
        private bool _isReloading;

        public MainViewModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;
            ReloadCommad = new RelayCommand(LoadDataAsync);
            PagingCommand = new RelayCommand<string>(Paging);
            Title = nameof(MainViewModel);
            LoadDataAsync();
        }
        public ICommand ReloadCommad { get; private set; }
        public ICommand PagingCommand { get; private set; }
        public async void LoadDataAsync()
        {
            IsReloading = true;
            Recipes = await _recipeService.GetRecipeAsync();
            IsReloading = false;
        }

        public void Paging(string param)
        {
            if (param == "next")
            {
                //
            }
            ReloadCommad.Execute(null);
        }
        public string Title { get; set; }

        public Recipe SelectedRecipe
        {
            get { return _selecedRecipe; }
            set
            {
                Set(ref _selecedRecipe, value);
                _selectedIndex = Recipes.IndexOf(value);
                RaisePropertyChanged(nameof(SelectedIndex));
            }
        }

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (Recipes != null)
                {
                    SelectedRecipe = Recipes[value];
                }
                Set(ref _selectedIndex, value);
            }

        }
        public IList<Recipe> Recipes
        {
            get { return _recipes; }
            set
            {
                       
                Set(ref _recipes, value);
            }
        }

        public bool IsReloading
        {
            get { return _isReloading; }
            set
            {
                Set(ref _isReloading, value);
            }
        }
    }
}
