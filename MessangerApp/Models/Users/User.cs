using System.Text.Json.Serialization;
using MessangerApp.Models.Chats;

namespace MessangerApp.Models.Users;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Role Role { get; set; }

    [JsonIgnore]
    public string PasswordHash { get; set; }

	public List<UserBlackList> UserBlackLists { get; set; }
	public List<UserBlackList> BlacklistedUsers { get; set; }
	public List<Chat> OwnedChats { get; set; }
	public List<ChatMember> Memberships { get; set; }
	public List<ChatBlackList> ChatBlackLists { get; set; }
	public List<ChatInvitation> Invitations { get; set; }
	public List<ChatJoinRequest> JoinRequests { get; set; }
}
