using CRUDWithDapper.Data.DapperContext;
using CRUDWithDapper.DTOs;
using CRUDWithDapper.Models;
using CRUDWithDapper.Repositories.Interfaces;
using Dapper;
using System.Data;

namespace CRUDWithDapper.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly IDapperContext _context;

        public BranchRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Branch branch)
        {
            var query = "INSERT INTO " + typeof(Branch).Name + " (Name, Tel,Address,Code,BankId) VALUES (@Name, @Tel,@Address,@Code,@BankId)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", branch.Name, DbType.String);
            parameters.Add("BankId", branch.BankId, DbType.Int32);
            parameters.Add("Tel", branch.TelephoneNumber, DbType.String);
            parameters.Add("Address", branch.Address, DbType.String);
            parameters.Add("Code", branch.Code, DbType.String);

            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            var query = "DELETE FROM " + typeof(Branch).Name + " WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
            public async Task<IEnumerable<BranchDTO>> GetAllAsync()
        {
            var query = "select br.*,b.Name bankname from Branch as br join Bank as b on b.Id=br.BankId";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<BranchDTO>(query);
                return result.ToList();
            }
        }

        public async Task<Branch> GetByIdAsync(int id)
        {
            var query = "select br.*,b.Name bankname from Branch as br join Bank as b on b.Id=br.BankId  WHERE br.Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<Branch>(query, new { id });
                return result;
            }
        }

        public async Task UpdateAsync(Branch branch)
        {
            var query = "UPDATE Branch SET Name = @Name, Tel =@Tel    WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", branch.Id, DbType.Int64);
            parameters.Add("Name", branch.Name, DbType.String);
            parameters.Add("Tel", branch.TelephoneNumber, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
