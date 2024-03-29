﻿using MRSUTW.BusinessLogic.Core;
using MRSUTW.BusinessLogic.Interfaces;
using MRSUTW.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MRSUTW.BusinessLogic
{
     internal class SessionBL : UserApi, ISession
     {
          public PostResponse UserLogin(ULoginData data)
          {
               return UserLoginAction(data);
          }

          public PostResponse UserRegister(USignupData data)
          {
               return UserRegisterAction(data);
          }

          public HttpCookie GenCookie(string loginCredential)
          {
              return Cookie(loginCredential);
          }
          public UData GetProfileByCookie(string cookie)
          {
              return GetProfileByCookieAction(cookie);
          }
          public List<UData> GetUsers()
          {
              return GetUsersAction();
          }
          public UData GetProfileByEmail(string email)
          {
              return GetProfileByEmailAction(email);
          }
          public List<UData> DeleteUserById(int id)
          {
              return DeleteUserByIdAction(id);
          }
          public UData UpdateProfile(UData u)
          {
              return UpdateProfileAction(u);
          }
    }
}
