namespace MessangerApp.Entities.Messages;

public class AdditionalContent
{
	public int Id { get; set; }
	public string Type { get; set; }
	public string Payload { get; set; }

	public int MessageId { get; set; }
	public Message Message { get; set; }
}
