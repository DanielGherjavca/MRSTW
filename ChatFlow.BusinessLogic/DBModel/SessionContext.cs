using ChatFlow.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatFlow.BusinessLogic.DBModel
{
     internal class SessionContext : DbContext
     {
          public SessionContext() : base("name=ChatFlow")
          {
          }

          public virtual DbSet<Session> Sessions { get; set; }
     }
}
