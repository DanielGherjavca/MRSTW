using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatFlow.Domains.Entities
{
	public class Friends
	{
		public int ID { get; set; }
		public int userId { get; set; }
		public int friendId { get; set; }
		public DateTime friends_at { get; set; }

	}
}
