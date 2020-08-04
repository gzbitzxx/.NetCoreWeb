using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bit.Core.Web.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Bit.Core.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMemoryCache cache, ILogger<HomeController> logger)
        {
            _cache = cache;
            _logger = logger;
        }
        [Authorize]
        public IActionResult Index()
        {

            var userName = HttpContext.User.Claims.First().Value;
            _cache.Set("Name", "比特软件");
            _cache.Set("Desc", "贵州比特成立于2008年");
            ViewData["userName"] = userName;
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> AuthenticationFail()
        {
            return View();
        }
    }
}
