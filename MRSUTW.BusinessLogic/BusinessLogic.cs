using MRSUTW.BusinessLogic.Interfaces;

namespace MRSUTW.BusinessLogic
{
     public class BusinessLogic
     {
          public ISession GetSessionBL()
          {
               return new SessionBL();
          }
     }
}