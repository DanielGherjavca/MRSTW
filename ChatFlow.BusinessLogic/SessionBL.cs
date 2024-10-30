using ChatFlow.BusinessLogic.Core;
using ChatFlow.BusinessLogic.Interfaces;
using ChatFlow.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ChatFlow.BusinessLogic {
     public class SessionBL : UserApi, ISession {
          public ULoginResp UserRegister(URegisterData data)
          {
               return UserRegisterAction(data);
          }
          public ULoginResp UserLogin(ULoginData data)
          {
               return UserLoginAction(data);
          }
          public HttpCookie GenCookie(string loginEmail)
          {
               return Cookie(loginEmail);
          }

          public UserMinimal GetUserByCookie(string apiCookieValue)
          {
               return UserCookie(apiCookieValue);
          }
     }
}
