using MessangerApp.Models.Users;

namespace MessangerApp.Models.Chats;

public class ChatInvitation
{
	public int Id { get; set; }
	public JoinStatus Status { get; set; }

	public int UserId { get; set; }
	public int ChatId { get; set; }
	public int InvitedById { get; set; }

	public User User { get; set; }
	public Chat Chat { get; set; }
	public ChatMember InvitedBy { get; set; }
}
