using ChatFlow.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatFlow.BusinessLogic.DBModel
{
     public class TableContext : DbContext
     {
          public TableContext() : base("name=ChatFlow")
          {
          }
          public virtual DbSet<User> Users { get; set; }
          public virtual DbSet<Session> Sessions { get; set; }

     }
}
