using ChatFlow.Domains.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatFlow.Domains.Entities
{
     public class UserMinimal
     {
          public int Id { get; set; }
          public string Username { get; set; }
          public string Email { get; set; }
          public string Imageurl {get; set;}
          public URole Level { get; set; }
     }
}
