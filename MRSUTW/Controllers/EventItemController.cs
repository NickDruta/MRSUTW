using AutoMapper;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.Event;
using MRSUTW.Domain.Entities.User;
using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSUTW.Controllers
{
    public class EventItemController : Controller
    {
          private IEvent _event;

          public EventItemController()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _event = bl.GetEventBL();
          }
          // GET: EventItem
          public ActionResult Index(int id)
        {
               var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<EventData, Event>();
               });

               IMapper mapper = config.CreateMapper();
               Event ev = mapper.Map<Event>(_event.GetEvenimentById(id));

               return View(ev);
          }
    }
}