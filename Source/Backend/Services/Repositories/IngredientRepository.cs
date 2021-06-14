using System.Threading.Tasks;
using Backend.Models;
using Backend.Models.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Backend.RequestModels;

namespace Backend.Services.Repositories
{
    public class IngredientRepository : IIngredientRepository<Ingredient, int, string, AddIngredient>
    {
        private readonly FoodWeekContext _dbContext;

        public IngredientRepository(FoodWeekContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Delete(int id, string name)
        {
            var ingredient = await _dbContext.Ingredients.FirstOrDefaultAsync(x => x.IngredientName == name);

            if (ingredient != null)
            {
                _dbContext.Remove(ingredient);
            }
        }

        //FIXME: Check if is is possible to make a return type and how to implement it in the controller. 
        public async Task<Ingredient> Insert(AddIngredient entity)
        {
            //FIXME: Refactor to separate methods.
            // var recipe = await _dbContext.Recipes.FirstOrDefaultAsync(x => x.Id == id);

            Ingredient newIngredient = new Ingredient();
            newIngredient.IngredientName = entity.IngredientName;
            newIngredient.Amount = entity.IngredientAmount;
            _dbContext.Ingredients.Add(newIngredient);
            return newIngredient;
            // await Save();
        }

        public async Task MapToRecipe(Ingredient entity, int id)
        {
            var ingredient = await _dbContext.Ingredients.FirstOrDefaultAsync(x => x.IngredientName == entity.IngredientName);
            // var ingredientName = await _dbContext.Ingredients.FirstOrDefaultAsync(r => r.IngredientName == newIngredient.IngredientName);
            int ingredientId = ingredient.Id;

            IngredientRecipe thisIngredient = new IngredientRecipe();
            thisIngredient.IngredientId = ingredientId;
            thisIngredient.RecipeId = id;

            _dbContext.RecipeIngredients.Add(thisIngredient);
            await Save();
        }

        public async Task<IngredientRecipe> Update(Ingredient entity, string name, int id)
        {
            var ingredient = await _dbContext.RecipeIngredients
                   .Include(x => x.Ingredient)
                   .Include(x => x.Recipe)
                   .Where(r => r.RecipeId == id)
                   .Where(x => x.Ingredient.IngredientName == name)
                   .FirstOrDefaultAsync();

                   ingredient.Ingredient.IngredientName = entity.IngredientName;
                   ingredient.Ingredient.Amount = entity.Amount;

                   return ingredient;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}