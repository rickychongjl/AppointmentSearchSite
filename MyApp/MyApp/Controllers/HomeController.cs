using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyApp.Models;
using System.Text.Encodings.Web;
using MyApp.Repositories;
using MyApp.Entities;
using System.Web.Mvc;
//paging
using PagedList;
using PagedList.Mvc;
namespace MyApp.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;
       
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        //Search controller
        public IActionResult Search(string searchreq_name, string searchreq_date, int? page)
        {
            //When Search button is pressed, the name and data will be sent to TestModel to display the result back
            List<Appointment> model = new List<Appointment>();

            foreach (Appointment p in TestModel.GetAppointments(searchreq_name, searchreq_date))
            {
                model.Add(p);
            }

            //for paging purposes
            ViewBag.Page = page;
            ViewBag.MaxPage = (model.Count / 25) - (model.Count % 25 == 0 ? 1 : 0) + 1;
            return View(model.ToPagedList(page ?? 1, 25));

        }






    }
}
