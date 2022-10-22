using MessangerApp.Models.Chats;

namespace MessangerApp.DataAccess.Chats.Interfaces;

public interface IChatRoleDataAccessProvider
{
    void AddChatRoleRecord(ChatRole chatRole);
    void AddRange(List<ChatRole> chatRoles);
    void UpdateChatRoleRecord(ChatRole chatRole);
    void DeleteChatRoleRecord(int id);
    ChatRole GetChatRoleSingleRecord(int id);
    List<ChatRole> GetChatRoleRecords();
}
