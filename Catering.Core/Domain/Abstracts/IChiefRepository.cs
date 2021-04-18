using Catering.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Core.Domain.Abstracts
{
    public interface IChiefRepository
    {
        Chief Get(string name);


    }
}
