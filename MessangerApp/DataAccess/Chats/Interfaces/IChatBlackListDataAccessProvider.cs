using MessangerApp.Models.Chats;

namespace MessangerApp.DataAccess.Chats.Interfaces;

public interface IChatBlackListDataAccessProvider
{
    void AddChatBlackListRecord(ChatBlackList chatBlackList);
    void AddRange(List<ChatBlackList> chatBlackLists);
    void UpdateChatBlackListRecord(ChatBlackList chatBlackList);
    void DeleteChatBlackListRecord(int id);
    ChatBlackList GetChatBlackListSingleRecord(int id);
    List<ChatBlackList> GetChatBlackListRecords();
}
