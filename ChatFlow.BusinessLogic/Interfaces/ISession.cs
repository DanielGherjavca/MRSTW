using ChatFlow.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ChatFlow.BusinessLogic.Interfaces {
     public interface ISession {
          ULoginResp UserRegister(URegisterData data);
          ULoginResp UserLogin(ULoginData data);
          HttpCookie GenCookie(string loginEmail);
          UserMinimal GetUserByCookie(string apiCookieValue);

     }
}
