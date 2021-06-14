using System.Threading.Tasks;

namespace Backend.Services.Repositories
{
    public interface IIngredientRepository<T1, T2, T3> where T1 : class
    {
        Task Insert(T1 entity, T2 id);
        Task MapToRecipe(T1 entity, T2 id);
        Task Update(T1 entity, T3 name);
        Task Delete(T2 id, T3 name);
        Task Save();
    }
}