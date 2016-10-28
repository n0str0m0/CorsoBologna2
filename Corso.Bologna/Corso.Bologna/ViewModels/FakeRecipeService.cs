using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Bologna.Models;
using Corso.Bologna.Services;

namespace Corso.Bologna.ViewModels
{
    public class FakeRecipeService: IRecipeService
    {
        public async Task<IList<Recipe>> GetRecipeAsync()
        {
            return  new List<Recipe>
            {
                new Recipe { id = 0, Name = "ricetta 1"},
                new Recipe {id = 1, Name = "ricetta 2"},
                new Recipe {id = 2, Name = "ricetta 3"}
            };
        }
    }
}
