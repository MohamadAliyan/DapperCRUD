using Dapper;
using DapperCRUD.Data;
using DapperCRUD.Models;
using DapperCRUD.Repository.Interface;
using System.Data;
using static Dapper.SqlMapper;

namespace DapperCRUD.Repository.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDapperContext _context;
        private readonly IAddressRepository _addressRepository;
        public CustomerRepository(IDapperContext context, IAddressRepository addressRepository)
        {
            _context = context;
            _addressRepository = addressRepository;
        }

        public async Task<List<Customer>> GetAllAsync()
        {

            var query = "select * from customer";
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<Customer>(query);
            return result.ToList();

        }
        public async Task<Customer> GetById(int id)
        {

            var query = $"select * from customer where Id = {id}";
            using var connection = _context.CreateConnection();
            var result = await connection.QueryFirstAsync<Customer>(query);
            result.Addresses = _addressRepository.GetById(id);
            return result;
        }
    } 
}
