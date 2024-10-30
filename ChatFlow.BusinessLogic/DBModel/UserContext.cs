using System.Data.Entity;
using ChatFlow.Domains.Entities;

namespace ChatFlow.BusinessLogic.DBModel
{
	public class UserContext:DbContext
	{
		public UserContext():base("ChatFlow")
		{
		}
		public DbSet<User> Users { get; set; }
		public DbSet<Group> Groups { get; set; }
/*		public DbSet<Message> Messages { get; set; }
		public DbSet<GroupMembers> Chats { get; set; }
		public DbSet<Friends> Chat { get; set; }
		public DbSet<ChatRoom> ChatRoom { get; set; }
		public DbSet<ChatRoomMembers> ChatRoomMembers { get; set; }*/
	}	
}
