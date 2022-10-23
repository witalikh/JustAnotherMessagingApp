using MessangerApp.Entities.Chats;
using MessangerApp.DataAccess.Chats.Interfaces;
using MessangerApp.DataAccess.Contexts;

namespace MessangerApp.DataAccess.Chats.Providers;

public class ChatInvitationDataAccessProvider : IChatInvitationDataAccessProvider
{
    private readonly PostgreSqlContext _context;

    public ChatInvitationDataAccessProvider(PostgreSqlContext context)
    {
        _context = context;
    }

    public void AddChatInvitationRecord(ChatInvitation chatInvitation)
    {
        _context.ChatInvitations.Add(chatInvitation);
        _context.SaveChanges();
    }

    public void AddRange(List<ChatInvitation> chatInvitations)
    {
        _context.ChatInvitations.AddRange(chatInvitations);
        _context.SaveChanges();
    }

    public void UpdateChatInvitationRecord(ChatInvitation chatInvitation)
    {
        _context.ChatInvitations.Update(chatInvitation);
        _context.SaveChanges();
    }

    public void DeleteChatInvitationRecord(int id)
    {
        var entity = _context.ChatInvitations.FirstOrDefault(t => t.Id == id);
        _context.ChatInvitations.Remove(entity!);
        _context.SaveChanges();
    }

    public ChatInvitation GetChatInvitationSingleRecord(int id)
    {
        return _context.ChatInvitations.FirstOrDefault(t => t.Id == id);
    }

    public List<ChatInvitation> GetChatInvitationRecords()
    {
        return _context.ChatInvitations.ToList();
    }
}
