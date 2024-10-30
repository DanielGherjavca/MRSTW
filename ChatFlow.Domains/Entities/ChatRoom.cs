using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatFlow.Domains.Entities
{
	public class ChatRoom
	{
		public int roomId { get; set; }
		public string title { get; set; } = string.Empty;
		public string description { get; set; }

	}
}
