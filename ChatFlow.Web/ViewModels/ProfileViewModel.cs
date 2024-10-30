using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatFlow.Web.ViewModels
{
	public class ProfileViewModel
	{
		[Required, MinLength(5)]
		public string Username { get; set; } = string.Empty;

		[EmailAddress, Required]
		public string Email { get; set; }

		public string Imageurl { get; set; }

	}
}