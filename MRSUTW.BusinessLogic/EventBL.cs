using MRSUTW.BusinessLogic.Core;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic
{
     internal class EventBL: EventApi, IEvent
     {
          public List<EventData> GetEvents()
          {
               return GetEventsAction();
          }

          public EventData GetEvenimentById(int id)
          {
               return GetEvenimentByIdAction(id);
          }

          public void AddEveniment(EventData ev)
          {
               AddEvenimentAction(ev);
          }

          public List<EventData> RemoveEvenimentById(int id) 
          {
               return RemoveEvenimentByIdAction(id);
          }
     }
}
