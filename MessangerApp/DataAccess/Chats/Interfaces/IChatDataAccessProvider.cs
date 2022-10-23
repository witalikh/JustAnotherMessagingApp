using MessangerApp.Entities.Chats;

namespace MessangerApp.DataAccess.Chats.Interfaces;

public interface IChatDataAccessProvider
{
    void AddChatRecord(Chat chat);
    void AddRange(List<Chat> chats);
    void UpdateChatRecord(Chat chat);
    void DeleteChatRecord(int id);
    Chat GetChatSingleRecord(int id);
    List<Chat> GetChatRecords();
}
