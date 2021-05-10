using Catering.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Core.Domain.Abstracts
{
    public interface ICategoryRepository
    {
        List<CookCategory> Get();
        int Add(CookCategory category);
        bool Update(CookCategory category);
    }
}
