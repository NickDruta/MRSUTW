using MRSUTW.Domain.Entities.Event;
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
               EventData e = new EventData();
               e.title = "Title";
               e.description = "Description";
               
               List<EventData> list = new List<EventData>();
               list.Add(e);

               return list;
          }
     }
}
