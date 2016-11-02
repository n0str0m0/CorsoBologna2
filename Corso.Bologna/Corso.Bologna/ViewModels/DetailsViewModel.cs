using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Bologna.Models;
using GalaSoft.MvvmLight;

namespace Corso.Bologna.ViewModels
{
    public class DetailsViewModel: ViewModelBase
    {
        private Recipe _currentrecipe;
        private string _title;
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
            }
        }
    }
}
