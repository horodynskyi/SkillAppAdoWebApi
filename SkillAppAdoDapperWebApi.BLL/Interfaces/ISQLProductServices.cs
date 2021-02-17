using SkillManagement.DataAccess.Entities.SQLEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Interfaces
{
    public interface ISQLProductService
    {
   

        Task<IEnumerable<SQLProduct>> GetAllProducts();
        Task<SQLProduct> GetById(int id);
        Task<SQLProduct> AddProduct(SQLProduct product);
        Task<SQLProduct> UpdateProduct(SQLProduct product,int id);
        Task<SQLProduct> DeleteProduct(int Id);
        Task<IEnumerable<SQLProduct>> GetProductByCategoriesId(int Id);




    }
}
