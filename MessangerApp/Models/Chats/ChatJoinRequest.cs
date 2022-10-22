using MessangerApp.Models.Users;

namespace MessangerApp.Models.Chats;

public class ChatJoinRequest
{
	public int Id { get; set; }
	public JoinStatus Status { get; set; }

	public int UserId { get; set; }
	public int ChatId { get; set; }
	public int ApprovedById { get; set; }

	public User User { get; set; }
	public Chat Chat { get; set; }
	public ChatMember ApprovedBy { get; set; }
}
