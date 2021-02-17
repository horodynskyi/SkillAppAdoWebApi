using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Entities.SQLEntities;
namespace SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories
{
    public interface ISQLProductRepository : IGenericRepository<SQLProduct, int>
    {
        Task<IEnumerable<SQLProduct>> GetProductByCategoriesId(int id);
    }
}
