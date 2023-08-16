using DapperCRUD.Models;

namespace DapperCRUD.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetById(int id);

    }
}
