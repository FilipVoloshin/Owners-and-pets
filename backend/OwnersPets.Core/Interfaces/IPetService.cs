using OwnersPets.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OwnersPets.Core.Interfaces
{
    public interface IPetService
    {
        Task<IEnumerable<PetDTO>> GetAllAsync();
        PetDTO GetByIdAsync(int id);
        void CreateAsync(PetDTO pet);
        void UpdateAsync(PetDTO pet);
        void DeleteAsync(int id);
    }
}
