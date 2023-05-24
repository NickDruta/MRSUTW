using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.Event;
using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSUTW.Controllers
{
    public class AdminItemEventController : Controller
    {
          private IEvent _event;

          public AdminItemEventController()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _event = bl.GetEventBL();
          }
          // GET: AdminItemEvent
          public ActionResult Index()
        {
            return View();
        }

          public ActionResult Add(Event ev)
          {
               EventData evdb= new EventData 
               {
                    Title= ev.Title,
                    Description= ev.Description,
                    Created= DateTime.Now,
               };
              _event.AddEveniment(evdb);

                return Json(new { redirectUrl = Url.Action("Index", "Home") });

          }
     }
}