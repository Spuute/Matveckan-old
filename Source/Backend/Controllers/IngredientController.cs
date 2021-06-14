using System;
using Backend.Models;
using Backend.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Backend.Resources;
using Backend.RequestModels;
using Backend.Interfaces;
using System.Threading.Tasks;
using Backend.Services.Repositories;


namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly FoodWeekContext _dbContext;
        private readonly IIngredientRepository<Ingredient, int, string> _igredientRepository;

        public IngredientController(FoodWeekContext dbContext, 
        IIngredientRepository<Ingredient, int, string> igredientRepository) 
        {
            _dbContext = dbContext;
            _igredientRepository = igredientRepository;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Ingredients(int id, [FromBody] AddIngredient addIngredient) {

            _igredientRepository.Insert()
            // var recipe = _dbContext.Recipes.FirstOrDefault(x => x.Id == id);

            // Ingredient newIngredient = new Ingredient();
            // newIngredient.IngredientName = addIngredient.IngredientName;
            // newIngredient.Amount = addIngredient.IngredientAmount;
            // _dbContext.Ingredients.Add(newIngredient);
            // _dbContext.SaveChanges();

            // var ingredientName = _dbContext.Ingredients.FirstOrDefault(r => r.IngredientName == newIngredient.IngredientName);
            // int ingredientId = ingredientName.Id;

            // IngredientRecipe thisIngredient = new IngredientRecipe();
            // thisIngredient.IngredientId = ingredientId;
            // thisIngredient.RecipeId = id;

            // _dbContext.RecipeIngredients.Add(thisIngredient);
            // _dbContext.SaveChanges();

            // return Ok("Ingrediens tillagd till receptet");
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> AddIngredientToRecipe(int id, [FromBody] AddIngredient addIngredient) {

        //     var recipe = _dbContext.Recipes.FirstOrDefault(x => x.Id == id);

        //     Ingredient newIngredient = new Ingredient();
        //     newIngredient.IngredientName = addIngredient.IngredientName;
        //     newIngredient.Amount = addIngredient.IngredientAmount;
        //     _dbContext.Ingredients.Add(newIngredient);
        //     _dbContext.SaveChanges();

        //     var ingredientName = _dbContext.Ingredients.FirstOrDefault(r => r.IngredientName == newIngredient.IngredientName);
        //     int ingredientId = ingredientName.Id;

        //     IngredientRecipe thisIngredient = new IngredientRecipe();
        //     thisIngredient.IngredientId = ingredientId;
        //     thisIngredient.RecipeId = id;

        //     _dbContext.RecipeIngredients.Add(thisIngredient);
        //     _dbContext.SaveChanges();

        //     return Ok("Ingrediens tillagd till receptet");
        // }

        [HttpDelete]
        public async Task<IActionResult> Ingredient(int id, string inputIngredient) {
            var ingredient = _dbContext.Ingredients.Where(x => x.IngredientName == inputIngredient).FirstOrDefault();

            if(ingredient != null) {
            _dbContext.Ingredients.Remove(ingredient);
            _dbContext.SaveChanges();
            return Ok("Ingrediensen är borttagen.");
            }
            return BadRequest("Det finns ingen ingrediense med det namnet till detta recept");
        }
    }
}