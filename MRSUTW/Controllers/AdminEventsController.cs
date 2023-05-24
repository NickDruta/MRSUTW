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
using MRSUTW.Domain.Entities.User;

namespace MRSUTW.Controllers
{
     public class AdminEventsController : Controller
     {
          private IEvent _event;

          public AdminEventsController()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _event = bl.GetEventBL();
          }
          public ActionResult Index()
          {
               var userCookie = Request.Cookies["MRSUTW"];
               if (userCookie == null) { return RedirectToAction("Index", "SignIn"); }

               var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<EventData, Event>();
               });

               IMapper mapper = config.CreateMapper();

               List<EventData> eventDataList = _event.GetEvents();
               List<Event> listEvent = eventDataList.Select(eventData => mapper.Map<Event>(eventData)).ToList();

               return View(listEvent);
          }
          public ActionResult Delete(int id) 
          {
               var userCookie = Request.Cookies["MRSUTW"];
               if (userCookie == null) { return RedirectToAction("Index", "SignIn"); }

               var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<EventData, Event>();
               });

               IMapper mapper = config.CreateMapper();

               List<EventData> eventList = _event.RemoveEvenimentById(id);
               List<Event> events = eventList.Select(eventData => mapper.Map<Event>(eventData)).ToList();


               return View("Index", events);
          }
     }
}