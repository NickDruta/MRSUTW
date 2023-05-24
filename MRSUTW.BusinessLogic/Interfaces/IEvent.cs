using MRSUTW.Domain.Entities.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic.Interfaces
{
     public interface IEvent
     {
          List<EventData> GetEvents();
          EventData GetEvenimentById(int id);
          void AddEveniment(EventData ev);
          List<EventData> RemoveEvenimentById(int id);
     }
}
