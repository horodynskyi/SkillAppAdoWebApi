using SkillManagement.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillManagement.DataAccess.Interfaces.SQLInterfaces.ISQLRepositories;


namespace SkillManagement.DataAccess.Interfaces
{
    public interface ISQLUnitOfWork
    {
        ISQLProductRepository SQLProductRepository { get; }
        ISQLCategoriesRepository SQLCategoriesRepository { get; }
        ISQLValuesRepository SQLValuesRepository { get; }
        ISQLAttributeRepository SQLAttributeRepository { get; }
        void Complete();
    }
}
