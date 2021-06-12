using System;
using Backend.Models;
using Backend.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Backend.Resources;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly FoodWeekContext _dbContext;

        public IngredientController(FoodWeekContext dbContext) {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Ingredients() {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public IActionResult AddIngredientToRecipe(int id) {

            Recipe recipe = _dbContext.Recipes.FirstOrDefault(x => x.Id == id);

            Ingredient newIngredient = new Ingredient();
            newIngredient.IngredientName = "potatisgratäng";
            newIngredient.Amount = "2 pkt";
            _dbContext.Ingredients.Add(newIngredient);
            _dbContext.SaveChanges();

            var ingredientName = _dbContext.Ingredients.FirstOrDefault(r => r.IngredientName == newIngredient.IngredientName);
            int ingredientId = ingredientName.Id;

            IngredientRecipe thisIngredient = new IngredientRecipe();
            thisIngredient.IngredientId = ingredientId;
            thisIngredient.RecipeId = id;

            _dbContext.RecipeIngredients.Add(thisIngredient);
            _dbContext.SaveChanges();

            return Ok("Ingrediens tillagd till receptet");
        }

        [HttpDelete]
        public IActionResult Ingredient(int id, string inputIngredient) {
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