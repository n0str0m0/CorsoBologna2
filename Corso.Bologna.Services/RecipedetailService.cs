using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Corso.Bologna.Models;
using Newtonsoft.Json;

namespace Corso.Bologna.Services
{
    public class RecipedetailService : IRecipeDetailService
    {
        private const string BaseURI = "http://forchettina.azurewebsites.net/api/recipes/";

        public async Task<RecipeDetail> GetRecipeDetailAsync(int recipeID)
        {
            var httpClient = new HttpClient();
            string response = await httpClient.GetStringAsync(BaseURI + $"Get/{recipeID}");
            return JsonConvert.DeserializeObject<RecipeDetail>(response);
        }
    }
}
