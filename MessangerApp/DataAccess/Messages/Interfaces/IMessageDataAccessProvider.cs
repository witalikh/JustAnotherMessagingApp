using MessangerApp.Entities.Messages;

namespace MessangerApp.DataAccess.Messages.Interfaces;

public interface IMessageDataAccessProvider
{
    void AddMessageRecord(Message message);
    void AddRange(List<Message> messages);
    void UpdateMessageRecord(Message message);
    void DeleteMessageRecord(int id);
    Message GetMessageSingleRecord(int id);
    List<Message> GetMessageRecords();
}
