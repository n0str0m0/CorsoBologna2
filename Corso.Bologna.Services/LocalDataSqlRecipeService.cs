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
    public class LocalDataSqlRecipeService : IRecipeService
    {
        public LocalDataSqlRecipeService()
        {
            InitDB();
        }

        public async void InitDB()
        {
            var rootFolder = FileSystem.Current.LocalStorage;

            try
            {
                await CeckFile(Path.Combine(rootFolder.Path, "recipe.db"));
            }
            catch (FileNotFoundException)
            {

                Seed(Path.Combine(rootFolder.Path, "recipe.db"));
            }

           
        }
        public async Task  CeckFile(string path)
        {
            var filedb = await FileSystem.Current.LocalStorage.GetFileAsync(path);

        }
        public void Seed(string path)
        {
            using (SQLiteConnection connection = new SQLiteConnection(path))
            {
                connection.CreateTable<Recipe>();
                connection.Insert(new Recipe { id = 3, Name = "pippo" });
                connection.Commit();
            }
        }

        public async Task<IList<Recipe>> GetRecipeAsync()
        {
            var rootFolder = FileSystem.Current.LocalStorage;
           
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection(Path.Combine(rootFolder.Path, "recipe.db"));
           List<Recipe> recipes = new List<Recipe>(await connection.Table<Recipe>().ToListAsync());
           
           
            return recipes;
        }
    }
}
