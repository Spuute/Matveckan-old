using AutoMapper;
using Backend.Models;

namespace Backend.DTOs
{
    public class InstructionsDTO
    {
        public string Step { get; set; }
        public int StepNumber { get; set; }
    }

    public class InstructionsDTOto : Profile
    {
        public InstructionsDTOto() {
            CreateMap<Instruction, InstructionsDTO>();
        }
    }
}