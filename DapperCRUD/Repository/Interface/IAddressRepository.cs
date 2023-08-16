using DapperCRUD.Models;

namespace DapperCRUD.Repository.Interface
{
    public interface IAddressRepository
    {
        List<Address> GetById(int id);
        bool Add();
        void delet();
    }

}
