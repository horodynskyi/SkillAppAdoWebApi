using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Entities.SQLEntities;
namespace SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories
{
    public interface ISQLCategoriesRepository : IGenericRepository<SQLCategories, int>
    {

    }
}
