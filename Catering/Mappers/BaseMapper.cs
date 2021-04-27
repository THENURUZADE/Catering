using Catering.Core.Domain.Entities;
using Catering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Mappers
{
    public abstract class BaseMapper<T1,T2> where T1 : BaseControlModel where T2:BaseEntity
    {
        public abstract T1 Map(T2 t);
        public abstract T2 Map(T1 t);
    }
}
