using Microsoft.AspNetCore.Mvc;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillManagement.WebAPI.Controllers
{
    public class CategoriesController : ControllerBase
    {
        #region Propertirs
        ISQLCategoriesService _sqlCategoriesService;
        #endregion

        #region Constructors
        public CategoriesController(ISQLCategoriesService sqlCategoriesService)
        {
            _sqlCategoriesService = sqlCategoriesService;
        }
        #endregion

        #region APIs
        // GET: Get all categories
        [Route("Categories")]
        [HttpGet]
        public async Task<IEnumerable<SQLCategories>> Get()
        {
            return await _sqlCategoriesService.GetAllCategories();

        }
        [Route("Categories/{id}")]
        [HttpGet]
        public async Task<SQLCategories> Get(int id)
        {
            return await _sqlCategoriesService.GetById(id);

        }
        // POST: POST add categories
        [Route("Categories")]
        [HttpPost]
        public async Task Post([FromBody] SQLCategories categories)
        {
            await _sqlCategoriesService.AddCategories(categories);
        }

        [Route("Categories/{id}")]
        [HttpPut]
        public async Task Put([FromBody] SQLCategories categories, int id)
        {

            await _sqlCategoriesService.UpdateCategories(categories, id);

        }

        [Route("Categories/{id}")]
        [HttpDelete]
        public async Task Put(int id)
        {

            await _sqlCategoriesService.DeleteCategories(id);

        }
        #endregion
    }
}
