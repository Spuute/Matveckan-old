using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Services.Repositories
{
    public interface IIngredientRepository<T1, T2, T3, T4> where T1 : class where T4 : class
    {
        Task<Ingredient> Insert(T4 entity);
        Task MapToRecipe(T1 entity, T2 id);
        Task Update(T1 entity, T3 name);
        Task Delete(T2 id, T3 name);
        Task Save();
    }
}