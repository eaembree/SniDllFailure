using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EfDeploymentTest.Ef;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EfDeploymentTest.Models;

namespace EfDeploymentTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, MyDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Ef()
        {
            List<Log> logs = _dbContext.Logs.OrderByDescending(x => x.Id).Take(10).ToList();
            ViewBag.Logs = logs;
            return View();
        }
    }
}
