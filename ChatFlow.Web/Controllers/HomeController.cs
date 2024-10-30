using ChatFlow.BusinessLogic.Interfaces;
using ChatFlow.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatFlow.BusinessLogic.DBModel;
using ChatFlow.Domains.Entities;

namespace ChatFlow.Web.Controllers
{
    public class HomeController : BaseController
    {
		private readonly UserContext _context;
		private readonly ISession _session;
          public HomeController()
          {
               var bl = new BusinesLogic();
               _session = bl.GetSessionBL();
			_context = new UserContext();

		  }

        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }

		[HttpPost]
		public ActionResult createGroup(string term)
		{
		        
            var group = new Group();
            group.title = term;
            group.groupId = Guid.NewGuid().GetHashCode();
            group.description = term;
            group.created_at = DateTime.Now;
            if(ViewBag.User != null)
            {
				group.userId = ViewBag.User.Id;
			}
			else
            {
				return RedirectToAction("Login", "Account");
			}

            _context.Groups.Add(group);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");

		}


		// GET: Home
		public ActionResult Index()
        {
               GetUser();
            if(ViewBag.User == null)
            {
				return RedirectToAction("Login", "Account");
			}
            return View();

        }
          public void GetUser()
          {
               SessionStatus();
               var apiCookie = System.Web.HttpContext.Current.Request.Cookies["X-KEY"];

               string userStatus = (string)System.Web.HttpContext.Current.Session["LoginStatus"];
               if (userStatus != "logout")
               {
                    var profile = _session.GetUserByCookie(apiCookie.Value);
                    ViewBag.User = profile;
               }
               else if (userStatus == "logout")
               {
                    ViewBag.User = null;
               }
          }
     }
}