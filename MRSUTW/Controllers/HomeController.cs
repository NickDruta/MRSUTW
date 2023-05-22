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
    public class HomeController : Controller
    {
        private readonly ISession _session;
        private readonly IPereche _pereche;

        public HomeController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
            _pereche = bl.GetPerecheBL();
        }

        // GET: Home
        public ActionResult Index()
        {
            HomeData homeData = new HomeData();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PerecheData, Pereche>();
            });

            IMapper mapper = config.CreateMapper();

            List<PerecheData> perecheDataList = _pereche.getOrarToday();
            homeData.perecheList = perecheDataList.Select(perecheData => mapper.Map<Pereche>(perecheData)).ToList();

            return View(homeData);
        }
    }
}