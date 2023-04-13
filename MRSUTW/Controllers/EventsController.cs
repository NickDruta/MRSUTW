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
        EventContent db = new EventContent();
        public ViewResult EventUse()
          {
               return View(db.list.ToList());
          }
    }
}