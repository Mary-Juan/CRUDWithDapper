using CRUDWithDapper.Models;

namespace CRUDWithDapper.Repositories.Interfaces
{
    public interface IBankRepository
    {
        Task<List<Bank>> GetAllAsync();
    }
}
