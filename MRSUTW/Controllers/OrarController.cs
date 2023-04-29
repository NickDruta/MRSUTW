using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.Pereche;
using MRSUTW.Models;

namespace MRSUTW.Controllers
{
    public class OrarController : Controller
    {
        private readonly IPereche _pereche;
        public OrarController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _pereche = bl.GetPerecheBL();
        }

        // GET: Orar
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PerecheData, Pereche>();
            });

            IMapper mapper = config.CreateMapper();

            List<PerecheData> perecheDataList = _pereche.getOrar();
            List<Pereche> listPereche = perecheDataList.Select(perecheData => mapper.Map<Pereche>(perecheData)).ToList();

            return View(listPereche);
        }
    }
}