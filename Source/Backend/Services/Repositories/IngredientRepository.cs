using System.Threading.Tasks;
using Backend.Models;
using Backend.Models.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Backend.RequestModels;
using System.Collections.Generic;

namespace Backend.Services.Repositories
{
    public class IngredientRepository : IIngredientRepository
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
            Ingredient newIngredient = new Ingredient();
            newIngredient.IngredientName = entity.IngredientName;
            newIngredient.Amount = entity.IngredientAmount;
             await _dbContext.Ingredients.AddAsync(newIngredient);
            return newIngredient;
        }

        public async Task<IngredientRecipe> MapToRecipe(Ingredient entity, int id)
        {
            var ingredient = await _dbContext.Ingredients.FirstOrDefaultAsync(x => x.IngredientName == entity.IngredientName);
            int ingredientId = ingredient.Id;

            IngredientRecipe thisIngredient = new IngredientRecipe();
            thisIngredient.IngredientId = ingredientId;
            thisIngredient.RecipeId = id;

            if(!_dbContext.RecipeIngredients.Contains(thisIngredient))
            {
                await _dbContext.RecipeIngredients.AddAsync(thisIngredient);
                return thisIngredient;
            }

            return null;
        }

        public async Task<Ingredient> Update(AddIngredient entity, string name, int id)
        {
            var getIngredient = await _dbContext.RecipeIngredients
                   .Include(x => x.Ingredient)
                   .Include(x => x.Recipe)
                   .Where(r => r.RecipeId == id)
                   .Where(x => x.Ingredient.IngredientName == name)
                   .FirstOrDefaultAsync();

            var ingredient = await _dbContext.Ingredients.FindAsync(getIngredient.IngredientId);

            if(ingredient != null) 
            {
                ingredient.IngredientName = entity.IngredientName;
                ingredient.Amount = entity.IngredientAmount;
                _dbContext.Ingredients.Update(ingredient);
                return ingredient;
            }
            return null;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}