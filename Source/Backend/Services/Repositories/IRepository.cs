using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.DTOs;
using Backend.Resources;

namespace Backend.Services.Repositories
{
    public interface IRepository<T1, T2> where T1 : class
    {
        Task<IEnumerable<T1>> GetAll();
        Task<T1> GetById(T2 id);
        Task<T1> Insert(T1 entity);
        Task Delete(T2 id);
        Task Save();
        Task<RecipeDTO> GetRecipeWithIngredients(T2 id);
        Task<CompleteRecipeDTO> GetCompleteRecipe(int id);


    }
}