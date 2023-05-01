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
     }
}
