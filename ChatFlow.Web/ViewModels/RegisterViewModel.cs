using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatFlow.Web.ViewModels
{

    public class RegisterViewModel
	{
		[Required, MinLength(5)]
		public string Username { get; set; } = string.Empty;

		[Required, MinLength(5), DataType(DataType.Password)]
		public string Password { get; set; }

		[EmailAddress, Required]
		public string Email { get; set; }

		public string Imageurl { get; set; }

		public DateTime? CreatedOn { get; set; }
 
	}

}