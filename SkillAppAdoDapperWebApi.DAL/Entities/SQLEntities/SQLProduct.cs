using SkillAppAdoDapperWebApi.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillManagement.DataAccess.Entities.SQLEntities
{
    public class SQLProduct: IEntity<int>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int category_id { get; set; }
        
    }
}
