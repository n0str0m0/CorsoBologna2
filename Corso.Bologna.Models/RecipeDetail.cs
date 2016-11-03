using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Bologna.Models
{
    public class RecipeDetail : Recipe
    {
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public string IngredientsAdditionalInfo { get; set; }
        IEnumerable<Step> _steps;
        public IEnumerable<Step> Steps
        {
            get { return _steps; }
            set
            {
                if (value != null)
                {
                    for (int i = 0; i < value.Count(); i++)
                    {
                        value.ElementAt(i).Index = i + 1;
                    }
                }
                _steps = value;
            }
        }
        public string StepsAdditionalInfo { get; set; }
    }
}
