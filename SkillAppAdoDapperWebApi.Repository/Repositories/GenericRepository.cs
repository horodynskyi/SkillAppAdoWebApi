using Dapper;
using SkillManagement.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Core
{
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class
    {
        protected IConnectionFactory _connectionFactory;
        private readonly string _tableName;
        private readonly bool _isSoftDelete;

        public GenericRepository(IConnectionFactory connectionFactory, string tableName, bool isSoftDelete)
        {
            _connectionFactory = connectionFactory;
            _tableName = tableName;
            _isSoftDelete = isSoftDelete;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var stringOfColumns = string.Join(", ", GetColumns());
            var stringOfProperties = string.Join(", ", GetProperties(entity));
            var query = "SP_InsertRecordToTable";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                
                
                return await db.QueryFirstOrDefaultAsync<TEntity>(
                    sql: query,
                    param: new { P_tableName = _tableName, P_columnsString = stringOfColumns, P_propertiesString = stringOfProperties },
                    commandType: CommandType.StoredProcedure);
                
            }
        }

        public async Task<TEntity> Get(TId Id)
        {
            var query = "SP_GetRecordByIdFromTable";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return await db.QueryFirstOrDefaultAsync<TEntity>(query,
                    new { P_tableName = _tableName, P_Id = Id },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var query = "SP_GetAllRecordsFromTable";

            using (var db = _connectionFactory.GetSqlConnection)
            {
               return await  db.QueryAsync<TEntity>(query,
                    new { P_tableName = _tableName },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<TEntity> Update(TEntity entity, TId Id)
        {
            var columns = GetColumns();
            var properties = GetProperties(entity);
            columns = columns.Zip(properties, (column, property) => column + " = " + property);
            var stringOfColumns = string.Join(", ", columns);

            using (var db = _connectionFactory.GetSqlConnection)
            {
                var query = "SP_UpdateRecordInTable";

                return await db.QueryFirstOrDefaultAsync<TEntity>(
                    sql: query,
                    param: new { P_tableName = _tableName, P_columnsString = stringOfColumns, P_Id = Id },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<TEntity> Delete(TId Id)
        {
            if (_isSoftDelete)
            {
                var columns = GetColumns();
                var isActiveColumnUpdateString = columns.Where(e => e == "IsActive").Select(e => $"{e} = 0").FirstOrDefault();

                using (var db = _connectionFactory.GetSqlConnection)
                {
                    var query = "SP_UnActivateRecordStatementInTable";

                    var UnActivateStatement = await db.QueryFirstOrDefaultAsync<string>(
                        sql: query,
                        param: new { P_tableName = _tableName, P_columnsString = isActiveColumnUpdateString, P_Id = Id },
                        commandType: CommandType.StoredProcedure);

                    return await db.QueryFirstOrDefaultAsync<TEntity>(
                        sql: UnActivateStatement,
                        param: Id,
                        commandType: CommandType.Text);
                }
            }
            else
            {
                using (var db = _connectionFactory.GetSqlConnection)
                {
                    var query = "SP_DeleteRecordFromTable";
                    return await db.QueryFirstOrDefaultAsync<TEntity>(
                        sql: query,
                        param: new { P_tableName = _tableName, P_Id = Id },
                        commandType: CommandType.StoredProcedure);
                }
            }
        }

        private IEnumerable<string> GetColumns()
        {
            return typeof(TEntity)
                    .GetProperties()
                    .Where(e => e.Name != "id" && e.Name != "Duration" && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => e.Name);
        }

        private IEnumerable<string> GetProperties(TEntity entity)
        {
            return typeof(TEntity)
                    .GetProperties()
                    .Where(e => e.Name != "id" && e.Name != "Duration" && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => '\'' + e.GetValue(entity).ToString() + '\'');
        }
    }
}

