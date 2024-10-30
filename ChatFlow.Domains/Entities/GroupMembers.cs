using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatFlow.Domains.Entities
{
	public class GroupMembers
	{
		public int Id { get; set; }
		public int groupId { get; set; }
		public int userId { get; set; }
		public string role { get; set; }
	}
}