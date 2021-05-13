using Catering.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Core.Domain.Abstracts
{
    public interface ICookRepository
    {
        int Add(Cook cook);
        bool Update(Cook cook);
        List<Cook> Get();
    }
}
