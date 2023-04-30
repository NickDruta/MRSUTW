using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.Pereche;

namespace MRSUTW.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IPereche _pereche;

        public RegisterController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _pereche = bl.GetPerecheBL();
        }
        // GET: Registru
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PerecheData, Pereche>();
            });

            IMapper mapper = config.CreateMapper();

            List<PerecheData> perecheDataList = _pereche.getRegister();
            List<Pereche> listPereche = perecheDataList.Select(perecheData => mapper.Map<Pereche>(perecheData)).ToList();

            return View(listPereche);
        }
    }
}