using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Bologna.Models;
using PCLStorage;

namespace Corso.Bologna.Services
{
    public class LocalDataSqlRecipeService: IRecipeService
    {
        public LocalDataSqlRecipeService()
        {
            var rootFolder = FileSystem.Current.LocalStorage;
           
        }

        public Task<IList<Recipe>> GetRecipeAsync()
        {
            return null;
        }
    }
}
