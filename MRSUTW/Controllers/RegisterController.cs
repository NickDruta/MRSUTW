using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.Pereche;
using MRSUTW.Domain.Entities.Marks;

namespace MRSUTW.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IMarks _marks;
        private readonly ISession _session;

        public RegisterController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _marks = bl.GetMarksBL();
            _session = bl.GetSessionBL();
        }
        // GET: Registru
        public ActionResult Index()
        {
            var userCookie = Request.Cookies["MRSUTW"];
            if (userCookie == null)
            {
                return RedirectToAction("Index", "SignIn");
            }

            RegisterData register = new RegisterData();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<MarksData, Marks>();
            });

            IMapper mapper = config.CreateMapper();

            List<MarksData> marksList = _marks.GetMarks();
            register.Marks = marksList.Select(marksData => mapper.Map<Marks>(marksData)).ToList();

            if (_session.GetProfileByCookie(userCookie.Value).Type == Domain.Enums.UType.Teacher)
            {
                register.IsEdit = true;
            } else
            {
                register.IsEdit = false;
            }

            return View(register);
        }
    }
}