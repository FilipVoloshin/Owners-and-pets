using OwnersPets.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OwnersPets.Core.Interfaces
{
    public interface IOwnerService
    {
        Task<IEnumerable<OwnerDTO>> GetAllAsync();
        OwnerDTO GetById(int id);
        void Create(OwnerDTO owner);
        void Update(OwnerDTO owner);
        void Delete(int id);
    }
}
