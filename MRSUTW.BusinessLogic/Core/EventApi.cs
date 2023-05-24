using MRSUTW.BusinessLogic.DBModel;
using MRSUTW.Domain.Entities.Event;
using MRSUTW.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic.Core
{
     internal class EventApi
     {
          public List<EventData> GetEventsAction()
          {
               List<EventData> events = new List<EventData>();

               using (var db = new UserContext())
               {
                    var eventsList = db.Evenimente.ToList();

                    foreach (var eventDb in eventsList)
                    {
                         var eventItem = new EventData
                         {
                              Id = eventDb.Id,
                              Title = eventDb.Title,
                              Description = eventDb.Description,
                              Created = eventDb.Created
                         };
                         events.Add(eventItem);
                    }
               }

               return events;
          }

          public EventData GetEvenimentByIdAction(int id)
          {
               EventData ev = new EventData();

               using (var db = new UserContext())
               {
                    var eventsList = db.Evenimente.ToList();

                    foreach (var eventDb in eventsList)
                    {
                         if (eventDb.Id == id)
                         {
                              ev = new EventData
                              {
                                   Id = eventDb.Id,
                                   Title = eventDb.Title,
                                   Description = eventDb.Description,
                                   Created = eventDb.Created
                              };
                         }
                    }
               }

               return ev;
          }

          public void AddEvenimentAction(EventData ev)
          {
               EDbTable eDb = new EDbTable
               {
                    Title = ev.Title,
                    Description = ev.Description,
                    Created = ev.Created
               };
               using (var db = new UserContext())
               {
                    db.Evenimente.Add(eDb);
                    db.SaveChanges();
               }
          }

          public List<EventData> RemoveEvenimentByIdAction (int id)
          {
               using (var db = new UserContext())
               {
                    var eventDb = db.Evenimente.Find(id);
                    if (eventDb != null)
                    {
                         db.Evenimente.Remove(eventDb);
                         db.SaveChanges();
                    }

                    List<EventData> eventsList = new List<EventData>();

                    var eventsDbList = db.Evenimente.ToList();

                    foreach (var ev in eventsDbList)
                    {
                         var eDb = new EventData
                         {
                              Id = ev.Id,
                              Title = ev.Title,
                              Description = ev.Description,
                              Created = ev.Created
                         };

                         eventsList.Add(eDb);
                    }

                    return eventsList;
               }
          }
     }
}
