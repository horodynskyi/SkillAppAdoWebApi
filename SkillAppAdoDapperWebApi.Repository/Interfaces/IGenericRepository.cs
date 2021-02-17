using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Interfaces
{
    public interface IGenericRepository<TEntity, TId> where TEntity : class
    {
         Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Get(TId Id);
        Task<TEntity> Update(TEntity entity, TId Id);
        Task<TEntity> Delete(TId Id);

       



          

         
    }
}