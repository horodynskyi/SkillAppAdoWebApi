using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Services
{
    public class SQLValuesService:ISQLValuesService
    {
        ISQLUnitOfWork _sqlunitOfWork;
        public SQLValuesService(ISQLUnitOfWork sqlunitOfWork)
        {
            _sqlunitOfWork = sqlunitOfWork;
        }

        public async Task<IEnumerable<SQLValues>> GetAllValues()
        {
            return await _sqlunitOfWork.SQLValuesRepository.GetAll();
        }
        public async Task<SQLValues> AddValues(SQLValues values)
        {

            return await _sqlunitOfWork.SQLValuesRepository.Add(values);

        }




        public async Task<SQLValues> GetById(int id)
        {
            return await _sqlunitOfWork.SQLValuesRepository.Get(id);
        }

        public async Task<SQLValues> UpdateValues(SQLValues values, int id)
        {
            return await _sqlunitOfWork.SQLValuesRepository.Update(values, id);
            //await Complete();
        }
        public async Task<SQLValues> DeleteValues(int id)
        {
            return await _sqlunitOfWork.SQLValuesRepository.Delete(id);
            //await Complete();
        }

        



        async Task Complete()
        {
            //await _sqlunitOfWork.Complete();
        }
    }
}
