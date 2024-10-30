using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatFlow.BusinessLogic.DBModel;
using ChatFlow.Web.ViewModels;
using ChatFlow.Domains.Entities;
using ChatFlow.BusinessLogic.Interfaces;
using ChatFlow.BusinessLogic;
using System.Web.UI.WebControls;
namespace ChatFlow.Web.Controllers
{
    public class AccountController : BaseController
    {

          private readonly ISession _session;
          public AccountController()
          {
               var bl = new BusinesLogic();
               _session = bl.GetSessionBL();
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


		// GET: Account
		[HttpGet]
		public ActionResult Register()
		{
            GetUser();
			if (ViewBag.User != null)
			{
				return RedirectToAction("Index", "Home");
			}
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Register(RegisterViewModel user)
		    {
               if (ModelState.IsValid)
               {
              
                    URegisterData uData = new URegisterData
                    {
                         Email = user.Email,
                         Password = user.Password,
                         Username = user.Username,
                         CreatedOn = DateTime.Now,
					    Imageurl = user.Imageurl
					};

                    ULoginResp loginResp = _session.UserRegister(uData);

                    if (loginResp.Status)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", loginResp.StatusMsg);
                         return View();
                    }
               }
               return View();
          }


		[HttpGet]
		public ActionResult Login()
		{
			GetUser();
			if (ViewBag.User != null)
			{
				return RedirectToAction("Index", "Home");
			}
			return View();
		}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
          //public ActionResult Login(LoginViewModel user)
          //{
          //	try
          //	{
          //		if (ModelState.IsValid)
          //		{
          //			using (UserContext db = new UserContext())
          //			{
          //				var obj = db.Users.Where(a => a.Email.Equals(user.Email) && a.Password.Equals(user.Password)).FirstOrDefault();
          //				if (obj != null)
          //				{
          //					// User is authenticated, handle accordingly (e.g., set session variables, redirect to home page)
          //					Session["UserID"] = obj.Id.ToString();
          //					Session["UserName"] = obj.Username;
          //					return RedirectToAction("Index", "Home");
          //				}
          //				else
          //				{
          //					// User is not authenticated, handle accordingly (e.g., display an error message)
          //					ModelState.AddModelError(string.Empty, "Invalid email or password.");
          //					return View(user);
          //				}
          //			}
          //		}
          //		else
          //		{
          //			// Handle invalid model state (e.g., display validation errors)
          //			return View(user);
          //		}
          //	}
          //	catch (Exception ex)
          //	{
          //		// Log the exception or handle it in a way appropriate for your application
          //		ModelState.AddModelError(string.Empty, ex.Message);
          //		return View(user);
          //	}
          //}	
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Login(LoginViewModel login)
          {
               if (ModelState.IsValid)
               {
                    ULoginData uData = new ULoginData
                    {
                         Email = login.Email,
                         Password = login.Password,
                    };

                    ULoginResp loginResp = _session.UserLogin(uData);

                    if (loginResp.Status)
                    {
                         HttpCookie cookie = _session.GenCookie(login.Email);
                         ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", loginResp.StatusMsg);
                         return View();
                    }
               }
               return View();
          }

		[HttpGet]
		public ActionResult Profile()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Profile(ProfileViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					using (UserContext db = new UserContext())
					{
						var userAlreadyExists = db.Users.Where(a => a.Username.Equals(model.Username)).FirstOrDefault();

						if (userAlreadyExists != null)
						{
							userAlreadyExists.Username = model.Username;
							db.SaveChanges();
							return RedirectToAction("Profile", "Account");
						}
						else
						{
							// User already exists, handle accordingly (e.g., display an error message)
							ModelState.AddModelError(string.Empty, "User with this username already exists.");
							return View(model);
						}
					}
				}
				else
				{
					// Handle invalid model state (e.g., display validation errors)
					return View(model);
				}
			}
			catch (Exception ex)
			{
				// Log the exception or handle it in a way appropriate for your application
				ModelState.AddModelError(string.Empty, ex.Message);
				return View(model);
			}

		}
	}
}
