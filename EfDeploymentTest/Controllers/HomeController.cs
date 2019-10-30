using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EfDeploymentTest.Ef;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EfDeploymentTest.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EfDeploymentTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
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
            List<Log> logs = new List<Log>();

            string connString = _config.GetConnectionString("DefaultConnection");
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string commandText = "SELECT TOP(10) Id, Message FROM [dbo].[Log] ORDER BY Id DESC";
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            logs.Add(new Log()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Message = reader.GetString(reader.GetOrdinal("Message"))
                            });
                            
                        }
                    }
                }
            }
            
            ViewBag.Logs = logs;
            return View();
        }
    }
}
