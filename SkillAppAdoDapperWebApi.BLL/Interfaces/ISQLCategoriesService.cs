using SkillManagement.DataAccess.Entities.SQLEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Interfaces
{
    public interface ISQLCategoriesService
    {
        

        Task<IEnumerable<SQLCategories>> GetAllCategories();
      
        Task<SQLCategories> GetById(int id);
        Task<SQLCategories> AddCategories(SQLCategories categories);
        Task<SQLCategories> UpdateCategories(SQLCategories categories, int id);
        Task<SQLCategories> DeleteCategories(int Id);
    }
}
