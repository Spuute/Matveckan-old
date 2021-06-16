using System.Collections.Generic;
using Backend.Models;
using Backend.Resources;

namespace Backend.DTOs
{
    public class CompleteRecipeDTO
    {
        public string Name { get; set; }
        public Category Categories { get; set; }
        public IEnumerable<IngredientDTO> Ingredients { get; set; }
        public IEnumerable<InstructionsDTO> Instructions { get; set; }
    }
}