using Dapper;
using DapperCRUD.Data;
using DapperCRUD.Models;
using System.Data;
using static Dapper.SqlMapper;

namespace DapperCRUD.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly IDapperContext _context;
        public BankRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<List<Bank>> GetAllAsync()
        {

            var query = "EXEC GetAllBank";
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<Bank>(query);
            return result.ToList();

        }

    }
}
