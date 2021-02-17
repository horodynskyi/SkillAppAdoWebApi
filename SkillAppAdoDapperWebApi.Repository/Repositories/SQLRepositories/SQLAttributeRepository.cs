using Microsoft.Extensions.Configuration;
using SkillManagement.DataAccess.Core;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Repositories
{
    public class SQLAttributeRepository : GenericRepository<SQLAttribute, int>, ISQLAttributeRepository
    {
        private static readonly string _tableName = "attributes";
        public SQLAttributeRepository(IConnectionFactory connectionFactory, IConfiguration config) : base(connectionFactory, _tableName, false)
        {
            var connectionString = config["connectionString:DefaultConnection"];
            connectionFactory.SetConnection(connectionString);
        }
    }
}
