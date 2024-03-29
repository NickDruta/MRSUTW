﻿using MRSUTW.BusinessLogic.Interfaces;

namespace MRSUTW.BusinessLogic
{
     public class BusinessLogic
     {
          public ISession GetSessionBL()
          {
               return new SessionBL();
          }

          public IPereche GetPerecheBL()
          {
              return new PerecheBL();
          }

          public IEvent GetEventBL()
          {
               return new EventBL();
          }

          public IMarks GetMarksBL()
          {
               return new MarksBL();
          }
     }
}