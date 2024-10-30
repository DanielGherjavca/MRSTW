using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using ChatFlow.Domains.Enums;

namespace ChatFlow.Domains.Entities
{
	[Table("Users")]
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string Username { get; set; } = string.Empty;

		[Required]
		[MaxLength(100)]
		public string Password { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[MaxLength(255)]
		public string Imageurl { get; set; }

		public DateTime CreatedOn { get; set; }

		public URole Level { get; set; }
	}
}