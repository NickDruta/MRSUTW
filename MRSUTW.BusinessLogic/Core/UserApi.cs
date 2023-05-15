using MRSUTW.BusinessLogic.DBModel;
using MRSUTW.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRSUTW.BusinessLogic.Core
{
     internal class UserApi
     {
          internal PostResponse UserLoginAction(ULoginData data)
          {
               return new PostResponse { Status = true };
          }

        internal PostResponse UserRegisterAction(USignupData data)
        {
            UDbTable result;
            if (data.Password == null || data.Email == null)
            {
                return new PostResponse { Status = false, StatusMsg = "Complet all fields" };
            }

            if (data.Password.Length < 8)
            {
                return new PostResponse { Status = false, StatusMsg = "Password min 8 characters" };
            }


            result = new UDbTable
            {  
                Password = data.Password,
                Email = data.Email,
                LastLogin = data.LoginDateTime,
                LasIp = data.LoginIp,
            };

            using (var db = new UserContext())
            {
                db.Users.Add(result);
                db.SaveChanges();

            }

            return new PostResponse { Status = true };
        }
    }
}
