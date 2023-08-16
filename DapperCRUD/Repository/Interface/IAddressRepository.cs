using DapperCRUD.Models;

namespace DapperCRUD.Repository.Interface
{
    public interface IAddressRepository
    {
        List<Address> GetById(int id);
        Task Create(CreatedAddressDTO address);
        Task Delete(int id);
    }

}
