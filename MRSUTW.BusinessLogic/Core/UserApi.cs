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
                    return new PostResponse { Status = false, StatusMsg = "Numele sau parola nu e corecta" };
                }

                if (!result.IsVerified)
                {
                    return new PostResponse { Status = false, StatusMsg = "Utilizatorul inca nu e verificat" };
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
                return new PostResponse { Status = false, StatusMsg = "E-Mail invalid" };
            }
        }

        internal PostResponse UserRegisterAction(USignupData data)
        {
            UDbTable result;
            string[] email = data.Email.Split('@');
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Email))
            {
                if (data.Password == null || data.Email == null)
                {
                    return new PostResponse { Status = false, StatusMsg = "Completeaza toate datele" };
                }
                
                if (email[1] != "isa.utm.md")
                {
                    return new PostResponse { Status = false, StatusMsg = "Nu este un email corporativ" };
                }

                if (data.Password.Length < 8)
                {
                    return new PostResponse { Status = false, StatusMsg = "Parolele minim 8 caractere" };
                }

                if (data.Email.Length < 5)
                {
                    return new PostResponse { Status = false, StatusMsg = "E-Mail incorect" };
                }

                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Email);
                }

                if (result != null)
                {
                    return new PostResponse { Status = false, StatusMsg = "E-Mail deja e ocupat" };
                }

                var pass = LoginHelper.HashGen(data.Password);
                result = new UDbTable
                {
                    Email = data.Email,
                    Password = pass,
                    LasIp = data.LoginIp,
                    LastLogin = data.LoginDateTime,
                    IsVerified = false,
                    Birthday = DateTime.Now,
                };

                using (var db = new UserContext())
                {
                    db.Users.Add(result);
                    db.SaveChanges();
                }

                EmailHelper EmailHelper = new EmailHelper();
                EmailHelper.SendEmail(data.Email, "Registrarea cu succes", "Bine te-am găsit la noi în platformă, UTMConnect. Accountul tău a fost înregistrat cu succes și urmează a fi verificat de către administratorii noștri.");

                return new PostResponse { Status = true };
            }
            else
            {
                return new PostResponse { Status = false, StatusMsg = "E-Mail invalid" };

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
                result = db.Users.FirstOrDefault(u => u.Email == loginCredential);
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

        internal UData GetProfileByCookieAction(string cookie)
        {
            SessionsDbTable session;
            UDbTable curentUser;

            using (var db = new UserContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.UserEmail))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.UserEmail);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.UserEmail);
                }
            }

            if (curentUser == null) return null;
            var userprofile = new UData
            {
                Id = curentUser.Id,
                Email = curentUser.Email,
                Group = curentUser.Group,
                Year = curentUser.Year,
                Faculty = curentUser.Faculty,
                PhoneNumber = curentUser.PhoneNumber,
                Cost = curentUser.Cost,
                GradeBuget = curentUser.GradeBuget,
                Birthday = curentUser.Birthday,
                Type = curentUser.Type,
                IsVerified = curentUser.IsVerified,
            };

            return userprofile;
        }
     }
}
