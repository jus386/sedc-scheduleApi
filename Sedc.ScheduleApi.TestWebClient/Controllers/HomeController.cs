using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sedc.ScheduleApi.TestWebClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult TestWebApiJquery()
        {
            return View();
        }

        public IActionResult TestWebApiDatatables()
        {
            return View();
        }

        public IActionResult TestSchedules()
        {
            return View();
        }

        public IActionResult TestReport()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
