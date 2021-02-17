using SkillManagement.DataAccess.Entities.SQLEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Interfaces
{
    public interface ISQLAttributeService
    {
        Task<IEnumerable<SQLAttribute>> GetAllAttributes();

        Task<SQLAttribute> GetById(int id);
        Task<SQLAttribute> AddAttributes(SQLAttribute attribute);
        Task<SQLAttribute> UpdateAttributes(SQLAttribute attribute, int id);
        Task<SQLAttribute> DeleteAttributes(int Id);
    }
}
