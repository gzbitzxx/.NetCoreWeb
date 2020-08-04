using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bit.Core.Web.Controllers
{
    [Controller]
    public class Job : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
