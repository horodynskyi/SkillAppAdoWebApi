

using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Services
{ 
    public class SQLAttributeService: ISQLAttributeService
    {
        ISQLUnitOfWork _sqlunitOfWork;
        public SQLAttributeService(ISQLUnitOfWork sqlunitOfWork)
        {
            _sqlunitOfWork = sqlunitOfWork;
        }

        public async Task<IEnumerable<SQLAttribute>> GetAllAttributes()
        {
            return await _sqlunitOfWork.SQLAttributeRepository.GetAll();
        }
        public async Task<SQLAttribute> AddAttributes(SQLAttribute attribute)
        {

            return await _sqlunitOfWork.SQLAttributeRepository.Add(attribute);

        }




        public async Task<SQLAttribute> GetById(int id)
        {
            return await _sqlunitOfWork.SQLAttributeRepository.Get(id);
        }

        public async Task<SQLAttribute> UpdateAttributes(SQLAttribute attribute, int id)
        {
            return await _sqlunitOfWork.SQLAttributeRepository.Update(attribute, id);
            //await Complete();
        }
        public async Task<SQLAttribute> DeleteAttributes(int id)
        {
            return await _sqlunitOfWork.SQLAttributeRepository.Delete(id);
            //await Complete();
        }

      



        async Task Complete()
        {
            //await _sqlunitOfWork.Complete();
        }
    }
}
