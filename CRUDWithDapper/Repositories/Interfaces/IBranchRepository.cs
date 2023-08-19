using CRUDWithDapper.DTOs;
using CRUDWithDapper.Models;

namespace CRUDWithDapper.Repositories.Interfaces
{
    public interface IBranchRepository
    {
        Task<IEnumerable<BranchDTO>> GetAllAsync();
        Task<Branch> GetByIdAsync(int id);
        Task CreateAsync(Branch branch);
        Task UpdateAsync(Branch branch);
        Task DeleteAsync(int id);
    }
}
