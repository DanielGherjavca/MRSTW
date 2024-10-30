using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatFlow.Domains.Entities
{
	public class Group
	{
		public int groupId { get; set; }
		public string title { get; set; } = string.Empty;
		public string description { get; set; }
		public DateTime created_at { get; set; }

		public int userId { get; set; }
	}
}