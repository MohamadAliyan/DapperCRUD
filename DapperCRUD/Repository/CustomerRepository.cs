using Dapper;
using DapperCRUD.Data;
using DapperCRUD.Models;
using System.Data;
using static Dapper.SqlMapper;

namespace DapperCRUD.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDapperContext _context;
        public CustomerRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllAsync()
        {

            var query = "select * from customer";
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<Customer>(query);
            return result.ToList();

        }

    }
}
