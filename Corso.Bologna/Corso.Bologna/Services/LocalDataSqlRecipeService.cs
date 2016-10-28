using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Bologna.Models;
using PCLStorage;
using SQLite;

namespace Corso.Bologna.Services
{
    public class LocalDataSqlRecipeService: IRecipeService
    {
        public LocalDataSqlRecipeService()
        {
            var rootFolder = FileSystem.Current.LocalStorage;
          
            using (SQLiteConnection connection = new SQLiteConnection(Path.Combine(rootFolder.Path, "recipe.db")))
            {
                connection.CreateTable<Recipe>();
                connection.Insert(new Recipe {id = 3, Name = "pippo"});
                connection.Commit();
            }
        }

        public async Task<IList<Recipe>> GetRecipeAsync()
        {
            var rootFolder = FileSystem.Current.LocalStorage;
            List<Recipe> recipes;
            recipes = new List<Recipe>();
            using (SQLiteConnection connection = new SQLiteConnection(Path.Combine(rootFolder.Path, "recipe.db")))
            {
               recipes.Add(connection.Find<Recipe>(0));
            }
            return recipes;
        }
    }
}
