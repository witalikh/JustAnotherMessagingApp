using MessangerApp.Models.Users;

namespace MessangerApp.Models.Chats;

public class ChatBlackList
{
	public int Id { get; set; }

	public int UserId { get; set; }
	public int ChatId { get; set; }

	public User User { get; set; }
	public Chat Chat { get; set; }
}
