﻿using Catering.Core.Domain.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.Web.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        protected readonly IUnitOfWork DB;
        public BaseController(IUnitOfWork db)
        {
            DB = db;
        }
    }
}