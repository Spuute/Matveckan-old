using System.Threading.Tasks;
using Backend.Resources;

namespace Backend.Services.Repositories
{
    public interface IRecipeRepository
    {
        Task<RecipeDTO> GetRecipeWithIngredients(int id);
    }
}