using System.Threading.Tasks;
using Corso.Bologna.Models;

namespace Corso.Bologna.Services
{
    public interface IRecipeDetailService
    {
        Task<RecipeDetail> GetRecipeDetailAsync(int recipeId);
    }
}