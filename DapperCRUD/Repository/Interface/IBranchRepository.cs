using DapperCRUD.Models;

namespace DapperCRUD.Repository.Interface
{
    public interface IBranchRepository
    {
        Task<IEnumerable<BranchDto>> GetAllAsync();
        Task<BranchDto> GetByIdAsync(int id);
        Task Create(Branch _Branch);
        Task Update(Branch _Branch);
        Task Delete(int id);
    }
}
