﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Attributes
{
    public class ExportAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
