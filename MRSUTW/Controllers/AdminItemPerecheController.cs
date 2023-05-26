using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.Event;
using MRSUTW.Domain.Entities.Pereche;
using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSUTW.Controllers
{
    public class AdminItemPerecheController : Controller
    {
        private IPereche _pereche;

        public AdminItemPerecheController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _pereche = bl.GetPerecheBL();
        }

        // GET: AdminItemPereche
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Pereche p)
        {
            PerecheData pDb = new PerecheData
            {
                Id = p.Id,
                Start = p.Start,
                End = p.End,
                TypeOfDay = p.TypeOfDay,
                WeekType = p.WeekType,
                ObiectType = p.ObiectType,
                Obiect = p.Obiect,
                Profesor = p.Profesor,
                Grupa = p.Grupa,
                Cabinet = p.Cabinet,
            };
            _pereche.AddPereche(pDb);

            return Json(new { redirectUrl = Url.Action("Index", "AdminPerechi") });
        }
    }
}