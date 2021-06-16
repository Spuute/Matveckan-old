using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Models.Data;
using System.Linq;
using Backend.Resources;
using Backend.DTOs;

namespace Backend.Services.Repositories
{
    public class RecipeRepository : IRepository<Recipe, int>, IRecipeRepository
    {
        private readonly FoodWeekContext _dbContext;

        public RecipeRepository(FoodWeekContext context)
        {
            _dbContext = context;
        }
        public async Task Delete(int id)
        {
            var recipe = await _dbContext.Recipes.FirstOrDefaultAsync(x => x.Id == id);

            if (recipe != null)
            {
                _dbContext.Remove(recipe);
            }
        }

        public async Task<IEnumerable<Recipe>> GetAll()
        {
            return await _dbContext.Recipes.ToListAsync();
        }

        public async Task<Recipe> GetById(int id)
        {

            return await _dbContext.Recipes.FindAsync(id);
        }

        public async Task<Recipe> Insert(Recipe entity)
        {
            await _dbContext.Recipes.AddAsync(entity);
            return entity;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<RecipeDTO> GetRecipeWithIngredients(int id)
        {

            var ingredientList = await _dbContext.RecipeIngredients
            .Include(x => x.Ingredient)
            .Include(x => x.Recipe)
            .Where(x => x.RecipeId == id)
            .Select(x => new IngredientDTO()
            {
                IngredientName = x.Ingredient.IngredientName,
                Amount = x.Ingredient.Amount
            }).ToListAsync();

            var recipe = await _dbContext.RecipeIngredients
                        .Include(x => x.Recipe)
                        .Include(x => x.Ingredient)
                        .Where(x => x.Recipe.Id == id)
                        .Select(x => new RecipeDTO()
                        {
                            Name = x.Recipe.Name,
                            Categories = x.Recipe.Category,
                            Ingredients = ingredientList
                        }).FirstOrDefaultAsync();

            return recipe;
        }

        public async Task<CompleteRecipeDTO> GetCompleteRecipe(int id)
        {
            var ingredientList = await _dbContext.RecipeIngredients
                .Include(x => x.Ingredient)
                .Include(x => x.Recipe)
                .Where(x => x.RecipeId == id)
                .Select(x => new IngredientDTO()
                {
                    IngredientName = x.Ingredient.IngredientName,
                    Amount = x.Ingredient.Amount
                }).ToListAsync();

            var InstructionList = await _dbContext.Instructions
                .Include(x => x.Recipe)
                .Where(x => x.RecipeId == id)
                .Select(x => new InstructionsDTO()
                {
                    Step = x.Step,
                    StepNumber = x.StepNumber
                }).ToListAsync();

            var recipe = await _dbContext.RecipeIngredients
                 .Include(x => x.Recipe)
                 .ThenInclude(x => x.Instructions)
                 .Include(x => x.Ingredient)
                 .Where(x => x.Recipe.Id == id)
                 .Select(x => new CompleteRecipeDTO()
                 {
                     Name = x.Recipe.Name,
                     Categories = x.Recipe.Category,
                     Ingredients = ingredientList,
                     Instructions = InstructionList
                 }).FirstOrDefaultAsync();

            return recipe;
        }
    }
}