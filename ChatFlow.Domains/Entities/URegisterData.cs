using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatFlow.Domains.Entities
{
     public class URegisterData
     {

          public string Username { get; set; }
          public string Email { get; set; }
          public string Password { get; set; }
          public DateTime CreatedOn { get; set; }
          public string Imageurl { get; set; }

     }
}
