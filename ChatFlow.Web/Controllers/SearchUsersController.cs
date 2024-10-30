using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ChatFlow.BusinessLogic.DBModel;
using ChatFlow.Domains.Entities;
using ChatFlow.BusinessLogic.Interfaces;
using ChatFlow.BusinessLogic;
using ChatFlow.BusinessLogic.Interfaces;
using ChatFlow.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace ChatFlow.Web.Controllers
{
	public class SearchUsersController : BaseController
	{
		private readonly ISession _session;
		private readonly UserContext _context;
		public SearchUsersController()
		{
			var bl = new BusinesLogic();
			_session = bl.GetSessionBL();
			_context = new UserContext();
		}


		 

		[HttpGet]
		public ActionResult Search()
		{
			 return View();
		}

		[HttpGet]
		public ActionResult getUsers(string term)
		{
			if (_context != null) { 
			var results = _context.Users
				.Where(u => u.Username.Contains(term))
				.Select(u => new { u.Id, u.Username, u.Imageurl }) // Selectează doar câmpurile necesare
				.ToList();

			return Json(results, JsonRequestBehavior.AllowGet);
			}return null;
		}


	}
}