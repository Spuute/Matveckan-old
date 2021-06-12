using AutoMapper;
using Backend.Models;
using Backend.Resources;

namespace Backend.Mapping
{
    public class ModelToIngredientResource : Profile
    {
        public ModelToIngredientResource()
        {
            CreateMap<Ingredient, IngredientResource>();
        }      
    }
}