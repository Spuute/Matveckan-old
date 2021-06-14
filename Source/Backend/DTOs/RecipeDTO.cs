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
        public IEnumerable<IngredientDTO> Ingredients { get; set; } 
    }

    //FIXME: Learn more about DTOs and Mapping.
    // public class RecipeDTOto : Profile
    // {
    //     public RecipeDTOto() {
    //         CreateMap<Recipe, RecipeDTO>();
    //         CreateMap<Ingredient, RecipeDTO>();
    //     }
    // }
}