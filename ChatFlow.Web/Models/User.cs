﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatFlow.Web.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		[Required, MinLength(5), Index(IsUnique = true), Column(TypeName = "VARCHAR")]
		public string Username { get; set; }

		[Required, MinLength(5), DataType(DataType.Password)]
		public string Password { get; set; }


		[EmailAddress, Index(IsUnique = true), Column(TypeName = "VARCHAR"), Required]
		public string Email { get; set; }

		[ScaffoldColumn(false)]
		public string Imageurl { get; set; }

		[ScaffoldColumn(false)]
		public DateTime? CreatedOn { get; set; }
	}
}