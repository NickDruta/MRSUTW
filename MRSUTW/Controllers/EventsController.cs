using MRSUTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRSUTW.Models;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.Pereche;
using MRSUTW.Domain.Entities.Event;
using AutoMapper;

namespace MRSUTW.Controllers
{
    public class EventsController : Controller
     {
          private IEvent _event;

          public EventsController()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _event = bl.GetEventBL();
          }
        public ActionResult Index()
          {
               var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<EventData, Event>();
               });

               IMapper mapper = config.CreateMapper();

               List<EventData> eventDataList = _event.GetEvents();
               List<Event> listEvent = eventDataList.Select(eventData => mapper.Map<Event>(eventData)).ToList();

               return View(listEvent);
          }
    }
}