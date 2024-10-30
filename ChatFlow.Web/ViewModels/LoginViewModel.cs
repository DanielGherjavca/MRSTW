using System.ComponentModel.DataAnnotations;

namespace ChatFlow.Web.ViewModels
{
	public class LoginViewModel
	{
		[Required, MinLength(5)]
		public string Email { get; set; }
		  
		[Required, MinLength(5), DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
