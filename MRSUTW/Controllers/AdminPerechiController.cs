using AutoMapper;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.Pereche;
using MRSUTW.Domain.Entities.User;
using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSUTW.Controllers
{
    public class AdminPerechiController : Controller
    {
        private IPereche _pereche;

        public AdminPerechiController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _pereche = bl.GetPerecheBL();
        }

        // GET: AdminPerechi
        public ActionResult Index()
        {
            var userCookie = Request.Cookies["MRSUTW"];
            if (userCookie == null) { return RedirectToAction("Index", "SignIn"); }

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PerecheData, Pereche>();
            });

            IMapper mapper = config.CreateMapper();

            List<PerecheData> perecheDataList = _pereche.GetPerechi();
            List<Pereche> perechi = perecheDataList.Select(PerecheData => mapper.Map<Pereche>(PerecheData)).ToList();

            return View(perechi);
        }

        public ActionResult Delete(int id)
        {
            var userCookie = Request.Cookies["MRSUTW"];
            if (userCookie == null) { return RedirectToAction("Index", "SignIn"); }

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PerecheData, Pereche>();
            });

            IMapper mapper = config.CreateMapper();

            List<PerecheData> perechiList = _pereche.RemovePerecheById(id);
            List<Pereche> perechi = perechiList.Select(perecheData => mapper.Map<Pereche>(perecheData)).ToList();


            return View("Index", perechi);
        }
    }
}