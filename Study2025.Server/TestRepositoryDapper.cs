using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Study2025.Server
{
    public class TestRepositoryDapper
    {
        private readonly string _connectionString;

        public TestRepositoryDapper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<TestItem>> GetAllItems()
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                return (await conn.QueryAsync<TestItem>("SELECT id, name, description, created_at FROM test_table")).ToList();
            }
        }
    }
}