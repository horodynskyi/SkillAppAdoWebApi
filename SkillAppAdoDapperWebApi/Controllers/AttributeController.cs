using Microsoft.AspNetCore.Mvc;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttributeController : ControllerBase
    {

        #region Propertirs
        ISQLAttributeService _sqlAttributeService;
        #endregion

        #region Constructors
        public AttributeController(ISQLAttributeService sqlAttributeService)
        {
            _sqlAttributeService = sqlAttributeService;
        }
        #endregion

        #region APIs
        // GET: Get all products

        [HttpGet]
        public async Task<IEnumerable<SQLAttribute>> Get()
        {
            return await _sqlAttributeService.GetAllAttributes();

        }

        // GET: Get by id product

        [HttpGet("{id}")]
        public async Task<SQLAttribute> Get(int id)
        {
            return await _sqlAttributeService.GetById(id);

        }


        // POST: POST add product

        [HttpPost]
        public async Task Post([FromBody] SQLAttribute attribute)
        {
            await _sqlAttributeService.AddAttributes(attribute);
        }


        [HttpPut("{id}")]
        public async Task Put([FromBody] SQLAttribute attribute, int id)
        {

            await _sqlAttributeService.UpdateAttributes(attribute, id);

        }

        [HttpDelete("{id}")]
        public async Task Put(int id)
        {

            await _sqlAttributeService.DeleteAttributes(id);

        }

        #endregion
    }
}
