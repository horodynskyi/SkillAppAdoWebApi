using SkillManagement.DataAccess.Interfaces;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.UnitOfWork
{
    public class SQLUnitOfWork : ISQLUnitOfWork
    {

        private readonly ISQLProductRepository _sqLProductRepository;

        private readonly ISQLCategoriesRepository _sqLCategoriesRepository;
        private readonly ISQLValuesRepository _sqLValuesRepository;
        ISQLAttributeRepository _sqLAttributeRepository;
        public SQLUnitOfWork(ISQLProductRepository sqlProductRepository,
             ISQLCategoriesRepository sqlCategoriesRepository,
             ISQLValuesRepository sqLValuesRepository,
              ISQLAttributeRepository sqLAttributeRepository)        
        {
            _sqLProductRepository = sqlProductRepository;
            _sqLCategoriesRepository = sqlCategoriesRepository;
            _sqLValuesRepository = sqLValuesRepository;
            _sqLAttributeRepository = sqLAttributeRepository;
        }
        public ISQLProductRepository SQLProductRepository
        {
            get
            {
                return _sqLProductRepository;
            }
        }

        public ISQLCategoriesRepository SQLCategoriesRepository
        {
            get
            {
                return _sqLCategoriesRepository;
            }
        }

        public ISQLValuesRepository  SQLValuesRepository
        {
            get
            {
                return _sqLValuesRepository;
            }
        }

        public ISQLAttributeRepository SQLAttributeRepository
        {
            get
            {
                return _sqLAttributeRepository;
            }
        }
        public void Complete()
        {
            throw new NotImplementedException();
        }

    }
}
