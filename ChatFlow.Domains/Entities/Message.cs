using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatFlow.Domains.Entities
{
	public class Message
	{
		public int messageId{ get; set; }
		public int? roomId { get; set; }
		public int? groupId { get; set; }
		public int userId { get; set; }
		public string message { get; set; }
		public DateTime created_at { get; set; }
		public DateTime updated_at { get; set; }

	}
}