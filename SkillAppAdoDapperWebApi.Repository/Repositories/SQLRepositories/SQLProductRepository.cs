using Dapper;
using Microsoft.Extensions.Configuration;
using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Repositories
{
    public class SQLProductRepository : GenericRepository<SQLProduct, int>, ISQLProductRepository
    {
        private static readonly string _tableName = "products";
        public SQLProductRepository(IConnectionFactory connectionFactory, IConfiguration config) : base(connectionFactory, _tableName, false)
        {
            var connectionString = config["connectionString:DefaultConnection"];
            connectionFactory.SetConnection(connectionString);
        }
        public async Task<IEnumerable<SQLProduct>> GetProductByCategoriesId(int id)
        {
            var query = "Select * from products as p where p.category_id="+id.ToString();

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return await db.QueryAsync<SQLProduct>(query);
            }
        }
    }
}

