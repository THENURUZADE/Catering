using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Core.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public User Creator { get; set; }
        public bool IsDeleted { get; set; }
    }
}
