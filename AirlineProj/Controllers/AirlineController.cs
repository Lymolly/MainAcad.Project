using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirlineProj.Controllers
{
    public class AirlineController : Controller
    {
        // GET: Airline
        public ActionResult Index()
        {
            return View();
        }
    }
}