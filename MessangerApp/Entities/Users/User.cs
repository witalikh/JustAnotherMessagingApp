using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using MessangerApp.Entities.Chats;

namespace MessangerApp.Entities.Users;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }

    [JsonIgnore]
    public string PasswordHash { get; set; }

	[InverseProperty("User")]
	public List<UserBlacklist> UserBlacklists { get; set; }

	[InverseProperty("BlacklistedUser")]
	public List<UserBlacklist> BlacklistedUsers { get; set; }

	public List<Chat> OwnedChats { get; set; }
	public List<ChatMember> Memberships { get; set; }
	public List<ChatBlacklist> ChatBlacklists { get; set; }
	public List<ChatInvitation> Invitations { get; set; }
	public List<ChatJoinRequest> JoinRequests { get; set; }
}
