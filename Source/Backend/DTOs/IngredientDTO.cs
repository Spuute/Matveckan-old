using AutoMapper;
using Backend.Models;

namespace Backend.Resources
{
    public class IngredientDTO
    {
        public string IngredientName { get; set; }
        public string Amount { get; set; }
        
    }

    //FIXME: Learn more about DTOs and Mapping.
    // public class IngredientDTOto : Profile
    // {
    //     public IngredientDTOto() {
    //         CreateMap<Ingredient, IngredientDTO>();
    //     }
    // }
}