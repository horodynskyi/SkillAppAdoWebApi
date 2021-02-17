using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Services
{
    public class SQLCategoriesService : ISQLCategoriesService
    {
        ISQLUnitOfWork _sqlunitOfWork;
        public SQLCategoriesService(ISQLUnitOfWork sqlunitOfWork)
        {
            _sqlunitOfWork = sqlunitOfWork;
        }

     

        public async Task<IEnumerable<SQLCategories>> GetAllCategories()
        {
            return await _sqlunitOfWork.SQLCategoriesRepository.GetAll();
        }

        public async Task<SQLCategories> AddCategories(SQLCategories categories)
        {

            return await _sqlunitOfWork.SQLCategoriesRepository.Add(categories);

        }

        public async Task<SQLCategories> GetById(int id)
        {
            return await _sqlunitOfWork.SQLCategoriesRepository.Get(id);
        }

        public async Task<SQLCategories> UpdateCategories(SQLCategories categories, int id)
        {
            return await _sqlunitOfWork.SQLCategoriesRepository.Update(categories, id);
            //await Complete();
        }
        public async Task<SQLCategories> DeleteCategories(int id)
        {
            return await _sqlunitOfWork.SQLCategoriesRepository.Delete(id);
            //await Complete();
        }

        async Task Complete()
        {
            //await _sqlunitOfWork.Complete();
        }
    }
    
}
