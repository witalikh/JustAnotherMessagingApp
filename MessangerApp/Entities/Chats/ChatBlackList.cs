using MessangerApp.Entities.Users;

namespace MessangerApp.Entities.Chats;

public class ChatBlacklist
{
	public int Id { get; set; }

	public int UserId { get; set; }
	public int ChatId { get; set; }

	public User User { get; set; }
	public Chat Chat { get; set; }
}
