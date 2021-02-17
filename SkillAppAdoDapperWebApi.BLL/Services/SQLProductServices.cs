using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Services
{
    public class SQLProductService : ISQLProductService
    {
        ISQLUnitOfWork _sqlunitOfWork;
        public SQLProductService(ISQLUnitOfWork sqlunitOfWork)
        {
            _sqlunitOfWork = sqlunitOfWork;
        }

        public async Task<IEnumerable<SQLProduct>> GetAllProducts()
        {
            return await _sqlunitOfWork.SQLProductRepository.GetAll();
        }
        public async Task<SQLProduct> AddProduct(SQLProduct product)
        {
            
            return await _sqlunitOfWork.SQLProductRepository.Add(product);
            
        }

     

      
        public async Task<SQLProduct> GetById(int id)
        {
            return await _sqlunitOfWork.SQLProductRepository.Get(id);
        }

        public async Task<SQLProduct> UpdateProduct(SQLProduct product,int id)
        {
            return await _sqlunitOfWork.SQLProductRepository.Update(product,id);
            //await Complete();
        }
        public async Task<SQLProduct> DeleteProduct(int id)
        {
            return await _sqlunitOfWork.SQLProductRepository.Delete(id);
            //await Complete();
        }

        public async Task<IEnumerable<SQLProduct>> GetProductByCategoriesId(int Id)
        {
            return await _sqlunitOfWork.SQLProductRepository.GetProductByCategoriesId(Id);
        }



        async Task Complete()
        {
            //await _sqlunitOfWork.Complete();
        }
    }
    
}
