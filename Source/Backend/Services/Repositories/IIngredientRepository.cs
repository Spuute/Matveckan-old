using System.Threading.Tasks;
using Backend.Models;
using Backend.RequestModels;

namespace Backend.Services.Repositories
{
    public interface IIngredientRepository
    {
        Task<Ingredient> Insert(AddIngredient entity);
        Task<IngredientRecipe> MapToRecipe(Ingredient entity, int id);
        Task<Ingredient> Update(AddIngredient entity, string name, int id);
        Task Delete(int id, string name);
        Task Save();
    }
}