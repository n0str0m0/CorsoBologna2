using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Bologna.Models;

namespace Corso.Bologna.Services
{
    public interface IRecipeService
    {
        Task<IList<Recipe>> GetRecipeAsync();
     
    }
}
