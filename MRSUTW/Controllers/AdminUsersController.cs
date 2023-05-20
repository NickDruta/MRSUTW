using AutoMapper;
using MRSUTW.BusinessLogic;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.User;
using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSUTW.Controllers
{
    public class AdminUsersController : Controller
    {
        private ISession _session;

        public AdminUsersController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }

        // GET: AdminUsers
        public ActionResult Index()
        {
            var userCookie = Request.Cookies["MRSUTW"];
            if (userCookie == null) { return RedirectToAction("Index", "Home"); }

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UData, User>();
            });

            IMapper mapper = config.CreateMapper();

            List<UData> usersProfileDataList = _session.GetUsers();
            List<User> users = usersProfileDataList.Select(usersProfileData => mapper.Map<User>(usersProfileData)).ToList();

            return View(users);
        }
    }
}