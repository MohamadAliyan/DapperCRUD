using DapperCRUD.Data;
using DapperCRUD.Models;
using Dapper;
using System.Data;
using static Dapper.SqlMapper;
using DapperCRUD.Repository.Interface;

namespace DapperCRUD.Repository.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IDapperContext _context;
        public AddressRepository(IDapperContext context)
        {
            _context = context;
        }
        public bool Add()
        {
            throw new NotImplementedException();
        }

        public void delet()
        {
            throw new NotImplementedException();
        }

        public List<Address> GetById(int id)
        {
            var query = $"select * from Address where customerId = {id}";
            using var connection = _context.CreateConnection();
            var result = connection.Query<Address>(query);
            return result.ToList();
        }
    }
}
