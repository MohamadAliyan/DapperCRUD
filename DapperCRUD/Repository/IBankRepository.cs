using DapperCRUD.Models;

namespace DapperCRUD.Repository
{
    public interface IBankRepository
    {
        Task<List<Bank>> GetAllAsync();
     
  
    }
}
