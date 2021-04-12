using Catering.Core.Domain.Abstracts;
using Catering.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Core
{
    public static class Kernel
    {
        public static User CurrentUser;
        public static IUnitOfWork DB;
    }
}
