using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Bologna.Models;
using Xamarin.Forms;

namespace Corso.Bologna.TeplatesSelector
{
    public class RecipeTemplateSelector: DataTemplateSelector
    {
        public  DataTemplate NormalDataTemplate { get; set; }
        public  DataTemplate MediaDataTemplate { get; set; }
        public DataTemplate DefaultDataTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var recipe = item as Recipe;
            if (recipe != null)
            {
                if (recipe.Level == "facile") return NormalDataTemplate;
                if (recipe.Level == "media") return MediaDataTemplate;
            }
            return DefaultDataTemplate;

        }
    }
}
