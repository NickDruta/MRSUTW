using MRSUTW.BusinessLogic.DBModel;
using MRSUTW.Domain.Entities.User;
using MRSUTW.Helpers.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MRSUTW.BusinessLogic.Core
{
     internal class UserApi
     {
        internal PostResponse UserLoginAction(ULoginData data)
        {

            UDbTable result;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Credential))
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Credential && u.Password == pass);
                }

                if (result == null)
                {
                    return new PostResponse { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())
                {
                    result.LasIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new PostResponse { Status = true };
            }
            else
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Username == data.Credential && u.Password == pass);
                }

                if (result == null)
                {
                    return new PostResponse { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())
                {
                    result.LasIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new PostResponse { Status = true };
            }
        }

        internal PostResponse UserRegisterAction(USignupData data)
        {
            UDbTable result;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Email))
            {
                if (data.Password == null || data.Email == null)
                {
                    return new PostResponse { Status = false, StatusMsg = "Complet all fields" };
                }

                if (data.Password.Length < 8)
                {
                    return new PostResponse { Status = false, StatusMsg = "Password min 8 characters" };
                }

                if (data.Email.Length < 5)
                {
                    return new PostResponse { Status = false, StatusMsg = "Username min 5 characters" };
                }

                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Email);
                }

                if (result != null)
                {
                    return new PostResponse { Status = false, StatusMsg = "The Email is already taken" };
                }

                var pass = LoginHelper.HashGen(data.Password);
                result = new UDbTable
                {
                    Email = data.Email,
                    Password = pass,
                    LasIp = data.LoginIp,
                    LastLogin = data.LoginDateTime,
                };

                using (var db = new UserContext())
                {
                    db.Users.Add(result);
                    db.SaveChanges();
                }

                return new PostResponse { Status = true };
            }
            else
            {
                return new PostResponse { Status = false, StatusMsg = "Invalid email" };

            }
        }

        internal HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("MRSUTW")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            //find email if username used
            UDbTable result;
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => u.Email == loginCredential || u.Username == loginCredential);
            }

            loginCredential = result.Email;


            using (var db = new UserContext())
            {
                SessionsDbTable curent;
                curent = (from e in db.Sessions where e.UserEmail == loginCredential select e).FirstOrDefault();

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var up = new UserContext())
                    {
                        up.Entry(curent).State = EntityState.Modified;
                        up.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new SessionsDbTable
                    {
                        UserEmail = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }
            return apiCookie;
        }
     }
}
