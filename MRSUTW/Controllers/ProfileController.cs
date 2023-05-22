using AutoMapper;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.User;
using MRSUTW.Models;
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
            if (userCookie == null)
            {
                return RedirectToAction("Index", "SignIn");
            }

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UData, User>();
            });

            IMapper mapper = config.CreateMapper();

            ProfileData data = new ProfileData();
            data.User = mapper.Map<User>(_session.GetProfileByCookie(userCookie.Value));
            if (data.User.Type == Domain.Enums.UType.Administrator)
            {
                data.IsEdit = true;
            } else
            {
                data.IsEdit = false;
            }

            return View(data);
        }

        [HttpGet]
        [ActionName("ShowUser")]
        public ActionResult Index(User u)
        {
            var userCookie = Request.Cookies["MRSUTW"];
            if (userCookie == null)
            {
                return RedirectToAction("Index", "SignIn");
            }

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UData, User>();
            });

            IMapper mapper = config.CreateMapper();

            ProfileData data = new ProfileData();
            User me = mapper.Map<User>(_session.GetProfileByCookie(userCookie.Value));
            data.User = u;
            if (me.Type == Domain.Enums.UType.Administrator)
            {
                data.IsEdit = true;
            }
            else
            {
                data.IsEdit = false;
            }

            return View("Index", data);
        }

        [HttpPost]
        public ActionResult Search(string searchData)
        {
            var userCookie = Request.Cookies["MRSUTW"];
            if (userCookie == null)
            {
                return Json(new { redirectUrl = Url.Action("Index", "SignIn") });
            }

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UData, User>();
            });
            IMapper mapper = config.CreateMapper();

            User u = mapper.Map<User>(_session.GetProfileByEmail(searchData));

            if (u != null)
            {
                return Json(new { redirectUrl = Url.Action("ShowUser", "Profile", u) });
            }
            else
            {
                return Json(new { redirectUrl = Url.Action("Index", "NotFound") });
            }
        }

        public ActionResult Update(User u)
        {
            var userCookie = Request.Cookies["MRSUTW"];
            if (userCookie == null)
            {
                return Json(new { redirectUrl = Url.Action("Index", "SignIn") });
            }
            ProfileData data = new ProfileData();
            UData udata = new UData
            {
                Id = u.Id,
                Email = u.Email,
                Group = u.Group,
                Year = u.Year,
                Faculty = u.Faculty,
                PhoneNumber = u.PhoneNumber,
                Cost = u.Cost,
                GradeBuget = u.GradeBuget,
                Birthday = u.Birthday,
                Type = u.Type,
                IsVerified = u.IsVerified,
            };

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UData, User>();
            });
            IMapper mapper = config.CreateMapper();

            User user = mapper.Map<User>(_session.UpdateProfile(udata));

            return RedirectToAction("Index", user);
        }
    }
}
