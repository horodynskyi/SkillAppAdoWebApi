using Microsoft.AspNetCore.Mvc;
using SkillManagement.DataAccess.Entities.SQLEntities;
using SkillManagement.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {

        #region Propertirs
        ISQLValuesService _sqlValuesService;
        #endregion

        #region Constructors
        public ValuesController(ISQLValuesService sqlValuesService)
        {
            _sqlValuesService = sqlValuesService;
        }
        #endregion

        #region APIs
        // GET: Get all products

        [HttpGet]
        public async Task<IEnumerable<SQLValues>> Get()
        {
            return await _sqlValuesService.GetAllValues();

        }

        // GET: Get by id product

        [HttpGet("{id}")]
        public async Task<SQLValues> Get(int id)
        {
            return await _sqlValuesService.GetById(id);

        }
        

        // POST: POST add product

        [HttpPost]
        public async Task Post([FromBody] SQLValues values)
        {
            await _sqlValuesService.AddValues(values);
        }


        [HttpPut("{id}")]
        public async Task Put([FromBody] SQLValues values, int id)
        {

            await _sqlValuesService.UpdateValues(values, id);

        }

        [HttpDelete("{id}")]
        public async Task Put(int id)
        {

            await _sqlValuesService.DeleteValues(id);

        }

        #endregion
    }
}
