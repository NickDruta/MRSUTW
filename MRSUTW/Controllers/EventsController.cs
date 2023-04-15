using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRSUTW.Models;

namespace MRSUTW.Controllers
{
    public class EventsController : Controller
     { 
        public ActionResult Index()
          {
               Event e = new Event();
               e.title = "Title";
               e.description = "Description";
               return View(e);
          }
    }
}