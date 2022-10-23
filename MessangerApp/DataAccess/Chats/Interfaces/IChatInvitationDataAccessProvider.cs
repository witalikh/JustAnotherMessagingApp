using MessangerApp.Entities.Chats;

namespace MessangerApp.DataAccess.Chats.Interfaces;

public interface IChatInvitationDataAccessProvider
{
    void AddChatInvitationRecord(ChatInvitation chatInvitation);
    void AddRange(List<ChatInvitation> chatInvitations);
    void UpdateChatInvitationRecord(ChatInvitation chatInvitation);
    void DeleteChatInvitationRecord(int id);
    ChatInvitation GetChatInvitationSingleRecord(int id);
    List<ChatInvitation> GetChatInvitationRecords();
}
