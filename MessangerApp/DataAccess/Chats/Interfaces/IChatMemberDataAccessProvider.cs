using MessangerApp.Entities.Chats;

namespace MessangerApp.DataAccess.Chats.Interfaces;

public interface IChatMemberDataAccessProvider
{
    void AddChatMemberRecord(ChatMember chatMember);
    void AddRange(List<ChatMember> chatMembers);
    void UpdateChatMemberRecord(ChatMember chatMember);
    void DeleteChatMemberRecord(int id);
    ChatMember GetChatMemberSingleRecord(int id);
    List<ChatMember> GetChatMemberRecords();
}
