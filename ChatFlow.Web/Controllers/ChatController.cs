using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;

namespace ChatFlow.Web.Controllers
{
	public class ChatHub : Hub
	{
		public void SendMessage(string user, string message)
		{
			Clients.All.addNewMessageToPage(user, message);
		}
	}

	public class ChatController : Controller
	{
		// GET: Home
		public ActionResult Index()
		{
			return View();
		}
	}
}