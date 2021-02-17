using Microsoft.AspNetCore.Mvc;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        
        #region Propertirs
        ISQLProductService _sqlProductService;
        #endregion

        #region Constructors
        public ProductController(ISQLProductService sqlProductService)
        {
            _sqlProductService = sqlProductService;
        }
        #endregion

        #region APIs
        // GET: Get all products
        
        [HttpGet]
        public async Task <IEnumerable<SQLProduct>> Get()
        {
            return await  _sqlProductService.GetAllProducts();
            
        }

        // GET: Get by id product
      
        [HttpGet("{id}")]
        public async Task<SQLProduct> Get(int id)
        {
            return await _sqlProductService.GetById(id);

        }
        [HttpGet("{categoryID:int}")]
        public async Task<IEnumerable<SQLProduct>> GetProductByCategoryId(int categoryID)
        {
            return await _sqlProductService.GetProductByCategoriesId(categoryID);
        }

        // POST: POST add product

        [HttpPost]
        public async Task Post([FromBody] SQLProduct product)
        {
            await _sqlProductService.AddProduct(product);  
        }

      
        [HttpPut("{id}")]
        public async Task Put([FromBody] SQLProduct product, int id)
        {
         
            await _sqlProductService.UpdateProduct(product,id);
            
        }
      
        [HttpDelete("{id}")]
        public async Task Put( int id)
        {

            await _sqlProductService.DeleteProduct(id);

        }

        #endregion
    }
}
