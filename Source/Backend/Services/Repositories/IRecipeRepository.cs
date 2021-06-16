using System.Threading.Tasks;
using Backend.DTOs;
using Backend.Resources;

namespace Backend.Services.Repositories
{
    public interface IRecipeRepository
    {
        Task<RecipeDTO> GetRecipeWithIngredients(int id);
        Task<CompleteRecipeDTO> GetCompleteRecipe(int id);
    }
}