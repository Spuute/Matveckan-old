using System.Collections.Generic;
using AutoMapper;
using Backend.Models;
using Backend.Resources;

namespace Backend.Mapping
{
    public class RecipeDTO
    {
        public string Name { get; set; } 
        public Category Categories { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }

    public class RecipeDTOto  : Profile
    {
        public RecipeDTOto() {
            CreateMap<Recipe, RecipeDTO>();
            CreateMap<Ingredient, RecipeDTO>();
        }
    }
}