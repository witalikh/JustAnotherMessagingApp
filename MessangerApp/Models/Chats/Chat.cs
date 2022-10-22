using MessangerApp.Models.Users;

namespace MessangerApp.Models.Chats;

public class Chat
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public bool IsMessagingOnByDefault { get; set; }
	public bool IsInvitesSendingOnByDefault { get; set; }
	public bool IsFilesSendingOnByDefault { get; set; }
	public string JoinLink { get; set; }
	public Visibility Visibility { get; set; }

	public int OwnerId { get; set; }

	public User Owner { get; set; }
	public List<ChatMember> Members { get; set; }
	public List<ChatBlackList> BlackLists { get; set; }
	public List<ChatInvitation> Invitations { get; set; }
	public List<ChatJoinRequest> JoinRequests { get; set; }
}
