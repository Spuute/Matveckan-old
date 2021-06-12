using System;
using Backend.Models;
using Backend.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Backend.Resources;
using System.Collections.Generic;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly FoodWeekContext _dbContext;

        public RecipeController(FoodWeekContext dbContext) {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllRecipes(){
            var allRecipes = _dbContext.Recipes.Select(x => x.Name).ToList();
            return Ok(allRecipes);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompleteRecipe(int id) { 
            var ingredientList = _dbContext.RecipeIngredients
            .Include(x => x.Ingredient)
            .Include(x => x.Recipe)
            .Where(x => x.RecipeId == id)
            .Select(x => new IngredientDTO() {
                IngredientName = x.Ingredient.IngredientName,
                Amount = x.Ingredient.Amount
            }).ToList();

            var dish1 = _dbContext.RecipeIngredients
                        .Include(x => x.Recipe)
                        .Include(x => x.Ingredient)
                        .Where(x => x.Recipe.Id == id)
                        .Select(x => new RecipeDTO() {
                            Name = x.Recipe.Name,
                            Categories = x.Recipe.Category,
                            Ingredients = ingredientList
                        }).FirstOrDefault();

            return Ok(dish1);
        }

        [HttpPost]
        public IActionResult AddRecipe([FromBody] Recipe recipe) {
            try {
                _dbContext.Recipes.Add(recipe);
                _dbContext.SaveChanges();
                return Ok("Recept tillagt i databasen.");
            }
            catch {
                return Conflict();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id) {
            var recipe = _dbContext.Recipes.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(recipe);
            _dbContext.SaveChanges();
            return Ok("Recept borttaget");
        }
    }
}