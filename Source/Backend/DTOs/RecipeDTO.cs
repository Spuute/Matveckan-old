using System.Collections.Generic;
using AutoMapper;
using Backend.Models;
using Backend.Resources;

namespace Backend.Resources
{
    public class RecipeDTO
    {
        public string Name { get; set; } 
        public Category Categories { get; set; }
        public List<IngredientDTO> Ingredients { get; set; } = new List<IngredientDTO>();
    }

    // public class RecipeDTOto  : Profile
    // {
    //     public RecipeDTOto() {
    //         CreateMap<Recipe, RecipeDTO>();
    //         CreateMap<Ingredient, RecipeDTO>();
    //     }
    // }
}