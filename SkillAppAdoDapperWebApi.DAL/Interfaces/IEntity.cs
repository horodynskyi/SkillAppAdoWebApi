using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillAppAdoDapperWebApi.DAL.Interfaces
{

    public interface IEntity<T>
    {
        T id { get; set; }
    }
}
