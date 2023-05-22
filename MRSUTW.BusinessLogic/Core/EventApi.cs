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
     }
}
