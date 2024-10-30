using AutoMapper;
using ChatFlow.BusinessLogic.DBModel;
using ChatFlow.Domains.Entities;
using ChatFlow.Domains.Enums;
using ChatFlow.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ChatFlow.BusinessLogic.Core {
     public class UserApi {
          public ULoginResp UserLoginAction(ULoginData data)
          {
               User result;
               var validate = new EmailAddressAttribute();
               if (validate.IsValid(data.Email))
               {
                    //var pass = LoginHelper.HashGen(data.Password);
                    using (var db = new UserContext())
                    {
                         using (var transaction = db.Database.BeginTransaction())
                         {
                              try
                              {
                                   result = db.Users.FirstOrDefault(u => u.Email == data.Email && u.Password == data.Password);

                                   if (result == null)
                                   {
                                        return new ULoginResp { Status = false, StatusMsg = "The Email or Password is Incorrect" };
                                   }

                                   return new ULoginResp { Status = true };
                              }
                              catch (Exception ex)
                              {
                                   transaction.Rollback();

                                   return new ULoginResp { Status = false, StatusMsg = "An error occurred while updating the password." };
                              }
                         }
                    }
               }
               else
                    return new ULoginResp { Status = false, StatusMsg = "Incorrect Email or Password" };
          }
          public ULoginResp UserRegisterAction(URegisterData data)
          {
               User user;
               var validate = new EmailAddressAttribute();
               if (validate.IsValid(data.Email))
               {
                    //var pass = LoginHelper.HashGen(data.Password);
                    using (var db = new UserContext())
                    {
                         user = db.Users.FirstOrDefault(u => u.Email == data.Email);
                    }
                    if (user != null)
                    {
                         return new ULoginResp { Status = false, StatusMsg = "This user already exists" };
                    }
                    var newUser = new User()
                    {
                         Email = data.Email,
                         Username = data.Username,
                         Password = data.Password,
                         Imageurl = data.Imageurl,
                         CreatedOn = data.CreatedOn,
                         Level = URole.User,
                         
                    };
                    using (var todo = new UserContext())
                    {
                         todo.Users.Add(newUser);
                         todo.SaveChanges();
                    }
                    return new ULoginResp { Status = true };

               }
               else
               {
                    return new ULoginResp { Status = false, StatusMsg = "Email is not valid" };
               }
          }


          internal HttpCookie Cookie(string loginEmail)
          {
               var apiCookie = new HttpCookie("X-KEY")
               {
                    Value = CookieGenerator.Create(loginEmail)
               };

               using (var db = new SessionContext())
               {
                    Session curent;
                    var validate = new EmailAddressAttribute();
                    if (validate.IsValid(loginEmail))
                    {
                         curent = (from e in db.Sessions where e.Username == loginEmail select e).FirstOrDefault();
                    }
                    else
                    {
                         curent = (from e in db.Sessions where e.Username == loginEmail select e).FirstOrDefault();
                    }

                    if (curent != null)
                    {
                         curent.CookieString = apiCookie.Value;
                         curent.ExpireTime = DateTime.Now.AddMinutes(160);
                         using (var todo = new SessionContext())
                         {
                              todo.Entry(curent).State = EntityState.Modified;
                              todo.SaveChanges();
                         }
                    }
                    else
                    {
                         db.Sessions.Add(new Session
                         {
                              Username = loginEmail,
                              CookieString = apiCookie.Value,
                              ExpireTime = DateTime.Now.AddMinutes(160)
                         });
                         db.SaveChanges();
                         List<Session> sessiolist = new List<Session>();
                         using (var transaction = db.Database.BeginTransaction())
                         {
                              sessiolist = db.Sessions.ToList();
                              if (sessiolist != null)
                              {
                                   foreach (Session session in sessiolist)
                                   {
                                        DateTime currentTime = DateTime.Now;
                                        if (session.ExpireTime < currentTime) // Check if the session has expired
                                        {
                                             db.Sessions.Remove(session);
                                        }
                                   }

                                   db.SaveChanges();
                                   transaction.Commit();
                              }
                         }
                    }
               }

               return apiCookie;
          }


          public UserMinimal UserCookie(string cookie)
          {
               Session session;
               User curentUser;

               using (var db = new SessionContext())
               {
                    session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
               }

               if (session == null) return null;
               using (var db = new UserContext())
               {
                    var validate = new EmailAddressAttribute();
                    if (validate.IsValid(session.Username))
                    {
                         curentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                    }
                    else
                    {
                         curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                    }
               }

               if (curentUser == null) return null;
               var userminimal = Mapper.Map<UserMinimal>(curentUser);

               return userminimal;
          }
     }
}
