namespace MessangerApp.Models.Chats;

public enum Role
{
    Admin,
    User
}

public class ChatRole
{
	public int Id { get; set; }
	public string Name { get; set; }
	public bool CanMessage { get; set; }
	public bool CanInvitePeople { get; set; }
	public bool CanSendFiles { get; set; }
	public bool CanApproveJoinRequests { get; set; }

	public int ChatId { get; set; }
	public Chat Chat { get; set; }
}
