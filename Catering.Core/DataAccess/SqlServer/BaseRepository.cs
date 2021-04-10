using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Core.DataAccess.SqlServer
{
    public abstract class BaseRepository
    {
        protected readonly SqlContext context;
        public BaseRepository(SqlContext context)
        {
            this.context = context;
        }
    }
}
