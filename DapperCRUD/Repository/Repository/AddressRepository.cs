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

        public async Task Create(CreatedAddressDTO address)
        {
            var query = "INSERT INTO Address (City, Street,Alley,PostalCode,CustomerId) VALUES (@City, @Street,@Alley,@PostalCode,@CustomerId)";
            var parameters = new DynamicParameters();
            parameters.Add("City", address.City, DbType.String);
            parameters.Add("Street", address.Street, DbType.String);
            parameters.Add("Alley", address.Alley, DbType.String);
            parameters.Add("CustomerId", address.CustomerId, DbType.Int32);
            parameters.Add("PostalCode", address.PostalCode, DbType.String);

            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(query, parameters);

        }

        public async Task Delete(int id)
        {
            var query = "DELETE FROM Address WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
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
