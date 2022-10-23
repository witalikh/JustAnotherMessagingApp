using MessangerApp.Entities.Users;
using MessangerApp.Entities.Messages;

namespace MessangerApp.Entities.Chats;

public class ChatMember
{
	public int Id { get; set; }

	public int UserId { get; set; }
	public int ChatId { get; set; }
	public int RoleId { get; set; }

	public User User { get; set; }
	public Chat Chat { get; set; }
	public ChatRole Role { get; set; }

	public List<ChatInvitation> SentInvitations { get; set; }
	public List<ChatJoinRequest> JoinRequestsToApprove { get; set; }
	public List<Message> Messages { get; set; }
}
