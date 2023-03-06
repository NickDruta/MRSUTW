using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSUTW.Controllers
{
    public class SingUpController : Controller
    {
        // GET: SingUp
        public ActionResult Index()
        {
            User u = new User();
            u.Username = "admin";
            u.Password = "parola";

            return View(u);
        }
    }
}