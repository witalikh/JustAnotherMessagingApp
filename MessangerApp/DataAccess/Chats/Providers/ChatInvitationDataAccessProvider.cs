using MessangerApp.Models.Chats;
using MessangerApp.DataAccess.Chats.Interfaces;
using MessangerApp.DataAccess.Chats.Contexts;

namespace MessangerApp.DataAccess.Chats.Providers;

public class ChatInvitationDataAccessProvider : IChatInvitationDataAccessProvider
{
    private readonly ChatInvitationPostgreSqlContext _context;

    public ChatInvitationDataAccessProvider(ChatInvitationPostgreSqlContext context)
    {
        _context = context;
    }

    public void AddChatInvitationRecord(ChatInvitation ChatInvitation)
    {
        _context.ChatInvitations.Add(ChatInvitation);
        _context.SaveChanges();
    }

    public void AddRange(List<ChatInvitation> ChatInvitations)
    {
        _context.ChatInvitations.AddRange(ChatInvitations);
        _context.SaveChanges();
    }

    public void UpdateChatInvitationRecord(ChatInvitation ChatInvitation)
    {
        _context.ChatInvitations.Update(ChatInvitation);
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
