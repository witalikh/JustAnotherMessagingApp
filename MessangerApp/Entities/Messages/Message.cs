using MessangerApp.Entities.Chats;
using MessangerApp.Models.Messages;

namespace MessangerApp.Entities.Messages;

public class Message
{
	public int Id { get; set; }
	public MessageStatus Status { get; set; }
	public string Payload { get; set; }
	public bool HasAdditionalContext { get; set; }
	public DateTime CreatedAt { get; set; }

	public int ChatId { get; set; }
	public int MemberId { get; set; }

	public Chat Chat { get; set; }
	public ChatMember ChatMember { get; set; }
	public List<AdditionalContent> AdditionalContents { get; set; }
}
