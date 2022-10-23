using MessangerApp.Entities.Chats;

namespace MessangerApp.DataAccess.Chats.Interfaces;

public interface IChatBlacklistDataAccessProvider
{
    void AddChatBlacklistRecord(ChatBlacklist chatBlackList);
    void AddRange(List<ChatBlacklist> chatBlackLists);
    void UpdateChatBlacklistRecord(ChatBlacklist chatBlackList);
    void DeleteChatBlacklistRecord(int id);
    ChatBlacklist GetChatBlacklistSingleRecord(int id);
    List<ChatBlacklist> GetChatBlacklistRecords();
}
