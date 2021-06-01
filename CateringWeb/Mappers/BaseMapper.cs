using Catering.Core.Domain.Entities;
using Catering.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.Web.Mappers
{
    public abstract class BaseMapper<T1,T2> where T1:BaseModel where T2:BaseEntity
    {
        public abstract T1 Map(T2 entity);
        public abstract T2 Map(T1 model);
    }
}
