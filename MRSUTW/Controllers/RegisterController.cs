using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSUTW.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Registru
        public ActionResult Index()
        {
            Pereche pereche1 = new Pereche();

            pereche1.Id = 0;
            pereche1.start = DateTime.Now.ToString("HH:mm");
            pereche1.end = DateTime.Now.AddMinutes(90).ToString("HH:mm");
            pereche1.typeOfDay = "Luni";
            pereche1.obiect = "Tw";
            pereche1.profesor = "Dragos Strainu";
            pereche1.cabinet = 518;
            pereche1.value = "a";

            return View(pereche1);
        }
    }
}