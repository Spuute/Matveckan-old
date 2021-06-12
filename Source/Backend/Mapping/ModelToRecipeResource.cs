using AutoMapper;
using Backend.Models;
using Backend.Resources;

namespace Backend.Mapping
{
    public class ModelToRecipeResource : Profile
    {
        public ModelToRecipeResource() {
            CreateMap<Recipe, RecipeResource>();
        }
    }
}