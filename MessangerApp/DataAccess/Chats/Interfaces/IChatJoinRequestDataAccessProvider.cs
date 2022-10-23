using MessangerApp.Entities.Chats;

namespace MessangerApp.DataAccess.Chats.Interfaces;

public interface IChatJoinRequestDataAccessProvider
{
    void AddChatJoinRequestRecord(ChatJoinRequest chatJoinRequest);
    void AddRange(List<ChatJoinRequest> chatJoinRequests);
    void UpdateChatJoinRequestRecord(ChatJoinRequest chatJoinRequest);
    void DeleteChatJoinRequestRecord(int id);
    ChatJoinRequest GetChatJoinRequestSingleRecord(int id);
    List<ChatJoinRequest> GetChatJoinRequestRecords();
}
