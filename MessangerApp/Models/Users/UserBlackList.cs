namespace MessangerApp.Models.Users;

public class UserBlackList
{
	public int Id { get; set; }
	public int UserId { get; set; }
	public int BlacklistedUserId { get; set; }

	public User User { get; set; }
	public User BlacklistedUser { get; set; }
}
