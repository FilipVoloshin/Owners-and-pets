using OwnersPets.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OwnersPets.Core.Interfaces
{
    public interface IPetService
    {
        Task<IEnumerable<PetDTO>> GetAllAsync();
        PetDTO GetById(int id);
        void Create(PetDTO pet);
        void Update(PetDTO pet);
        void Delete(int id);
    }
}
