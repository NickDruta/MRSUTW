﻿using MRSUTW.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MRSUTW.BusinessLogic.Interfaces
{
     public interface ISession
     {
          PostResponse UserLogin(ULoginData data);
          PostResponse UserRegister(USignupData data);
          HttpCookie GenCookie(string loginCredential);
    }
}
