using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Core.Domain.Entities
{
    public abstract class BaseEntityWithNote : BaseEntity
    {
        public string Note { get; set; }
    }
}
