using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Services.Repositories
{
    public interface IInstructionRepository
    {
        Task<Instruction> Insert();
        Task<Instruction> Update();
        Task<Instruction> Delete();
    }
}