using SkillManagement.DataAccess.Entities.SQLEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Interfaces
{
    public interface ISQLValuesService
    {
        Task<IEnumerable<SQLValues>> GetAllValues();
        Task<SQLValues> GetById(int id);
        Task<SQLValues> AddValues(SQLValues values);
        Task<SQLValues> UpdateValues(SQLValues values, int id);
        Task<SQLValues> DeleteValues(int Id);
    }
}
