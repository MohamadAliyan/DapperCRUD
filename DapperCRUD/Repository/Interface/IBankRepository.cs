using DapperCRUD.Models;

namespace DapperCRUD.Repository.Interface
{
    public interface IBankRepository
    {
        Task<List<Bank>> GetAllAsync();


    }
}
