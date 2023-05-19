using AutoMapper;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.User;
using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MRSUTW.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ISession _session;

        public ProfileController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }
        // GET: Profile
        public ActionResult Index()
        {
            var userCookie = Request.Cookies["MRSUTW"];
            if (userCookie == null) { return RedirectToAction("Index", "SignIn"); }

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UData, User>();
            });

            IMapper mapper = config.CreateMapper();

            User u = mapper.Map<User>(_session.GetProfileByCookie(userCookie.Value));

            return View(u);
        }
    }
}