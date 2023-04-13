using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSUTW.Models
{
     public class EventContent
     {
          public IEnumerable<Event> Events
          {
               get
               {
                    List<Event> list = new List<Event>();
                    {
                         new Event { number=1, title = "first event", description = "something interesting" },
                         new Event { number=2, title = "second event", description = "something here" }
                    }
                    return list;
               }
     }
}