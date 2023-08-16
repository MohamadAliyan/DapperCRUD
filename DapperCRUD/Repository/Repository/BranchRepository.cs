using Dapper;
using DapperCRUD.Data;
using DapperCRUD.Models;
using DapperCRUD.Repository.Interface;
using System.Data;
using static Dapper.SqlMapper;

namespace DapperCRUD.Repository.Repository
{
    public class BranchRepository : IBranchRepository
    {
        private readonly IDapperContext _context;
        public BranchRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BranchDto>> GetAllAsync()
        {
            //var query = "SELECT * FROM " + typeof(Branch).Name;
            var query = "select br.*,b.Name bankname from Branch as br join Bank as b on b.Id=br.BankId";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<BranchDto>(query);
                return result.ToList();
            }
        }
        public async Task<BranchDto> GetByIdAsync(int id)
        {
            //var query = "SELECT * FROM " + typeof(BranchDto).Name + " WHERE Id = @Id";
            var query = "select br.*,b.Name bankname from Branch as br join Bank as b on b.Id=br.BankId  WHERE br.Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<BranchDto>(query, new { id });
                return result;
            }
        }
        public async Task Create(Branch _Branch)
        {
            var query = "INSERT INTO " + typeof(Branch).Name + " (Name, Tel,Address,Code,BankId) VALUES (@Name, @Tel,@Address,@Code,@BankId)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", _Branch.Name, DbType.String);
            parameters.Add("BankId", _Branch.BankId, DbType.Int32);
            parameters.Add("Tel", _Branch.Tel, DbType.String);
            parameters.Add("Address", _Branch.Address, DbType.String);
            parameters.Add("Code", _Branch.Code, DbType.String);

            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(query, parameters);

        }
        public async Task Update(Branch _Branch)
        {
            var query = "UPDATE Branch SET Name = @Name, Tel =@Tel    WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", _Branch.Id, DbType.Int64);
            parameters.Add("Name", _Branch.Name, DbType.String);
            parameters.Add("Tel", _Branch.Tel, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task Delete(int id)
        {
            var query = "DELETE FROM " + typeof(Branch).Name + " WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}
